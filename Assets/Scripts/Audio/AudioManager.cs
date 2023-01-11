using System;
using System.Threading.Tasks;
using Audio.Assets;
using Global.Enums;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Pool;

namespace Audio
{
    public class AudioManager
    {

        private AudioAssets _audioAssets;

        private AudioSource _globalMusic;

        private ObjectPool<GameObject> _sfxSourcePool;


        public async Task Init()
        {
            // 加载资源
            _audioAssets = new AudioAssets();
            await _audioAssets.LoadAll();

            // SFX 对象池初始化
            _sfxSourcePool = new ObjectPool<GameObject>(() => new GameObject($"SFX_SOURCE"));
        }
        
        public void Inject(AudioSource globalSource)
        {
            _globalMusic = globalSource;
        }

        
        // ===================================== MUSIC ============================================================

        public void PlayMusic(MusicEnum musicName, AudioGroupEnum audioGroup)
        {
            _audioAssets.MusicClipAssets.TryGetValue(musicName, out var clip);
            if (clip == null)
            {
                Debug.LogWarning($"Didn't find audio clip for {musicName.ToString()}");
                return;
            }
            _globalMusic.clip = clip;
            _globalMusic.loop = true;
            _globalMusic.outputAudioMixerGroup = GetAudioGroup(audioGroup);
            _globalMusic.Play();
        }
        
        public void PauseMusic()
        {
            _globalMusic.Pause();
        }
    
        public void StopMusic()
        {
            _globalMusic.Stop();
        }
        
        
        // ========================================== SFX =========================================================
        
        public void PlaySFX(SFXEnum sfxName, Vector3 position, AudioGroupEnum audioGroup, Action<AudioSource> callback = null)
        {
            var sourceObj = _sfxSourcePool.Get();
            sourceObj.transform.position = position;
            var audioSource = sourceObj.AddComponent<AudioSource>();
            _audioAssets.SFXClipAssets.TryGetValue(sfxName, out var clip);
            audioSource.clip = clip;
            audioSource.outputAudioMixerGroup = GetAudioGroup(audioGroup);
            audioSource.Play();
            _sfxSourcePool.Release(sourceObj);
        }
        
        
        // =================================== AUDIO GROUP =========================================================
        
        public AudioMixerGroup GetAudioGroup(AudioGroupEnum group)
        {
            var groups = FindMatchingGroups(group);
            if (groups.Length > 0)
            {
                return groups[0];
            }
            Debug.LogWarning($"Didn't find audio group for {group}");
            return null;
        }
        
        public AudioMixerGroup[] FindMatchingGroups(AudioGroupEnum audioGroup)
        {
            var audioMixers = _audioAssets.AudioMixers;
            foreach (var mixer in audioMixers)
            {
                var results = mixer.FindMatchingGroups(audioGroup.ToString());
                if (results != null && results.Length != 0)
                {
                    return results;
                }
            }
            return null;
        }

        public void SetAudioGroupFloat(AudioGroupEnum name, float value)
        {
            foreach (var mixer in _audioAssets.AudioMixers)
            {
                mixer.SetFloat(name.ToString(), value);
            }
        }

        public void GetAudioGroupFloat(AudioGroupEnum name, out float value)
        {
            value = 0f;
            foreach (var mixer in _audioAssets.AudioMixers)
            {
                mixer.GetFloat(name.ToString(), out value);
                break;
            }
        }
        
        public void SetMasterVolume(float value)
        {
            if (value <= 0)
            {
                value = 0.001f;
            }
            var valueInDb = Mathf.Log10(value) * 20;
            SetAudioGroupFloat(AudioGroupEnum.Master, valueInDb);
        }

        public float GetMasterVolume()
        {
            GetAudioGroupFloat(AudioGroupEnum.Master, out var valueInDb);
            return Mathf.Pow(10f, valueInDb / 20.0f);
        }

    }
}