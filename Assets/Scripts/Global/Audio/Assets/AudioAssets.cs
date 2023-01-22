using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Global.Enums;
using UnityEngine;
using UnityEngine.Audio;
using Utils;

namespace Audio.Assets
{
    public class AudioAssets
    {
        
        /// <summary>
        /// 背景音乐资源
        /// </summary>
        private const string MusicClipAssetsTag = "MusicClipAssets";
        public Dictionary<MusicEnum, AudioClip> MusicClipAssets { get; private set; }

        /// <summary>
        /// 声音片段资源
        /// </summary>
        private const string SFXClipAssetsTag = "SFXClipAssets";
        public Dictionary<SFXEnum, AudioClip> SFXClipAssets { get; private set; }

        /// <summary>
        /// 音频组资源
        /// </summary>
        private const string AudioMixerAssetsTag = "AudioMixerAssets";
        public List<AudioMixer> AudioMixers { get; private set; }


        public AudioAssets()
        {
            MusicClipAssets = new Dictionary<MusicEnum, AudioClip>();
            SFXClipAssets = new Dictionary<SFXEnum, AudioClip>();
            AudioMixers = new List<AudioMixer>();
        }

        public async Task LoadAll()
        {
            await AddressableUtil.LoadWithLabel<AudioClip>(MusicClipAssetsTag, res =>
            {
                var enumKey = Enum.Parse<MusicEnum>(res.name);
                MusicClipAssets.Add(enumKey, res);
            });
            await AddressableUtil.LoadWithLabel<AudioClip>(SFXClipAssetsTag, res =>
            {
                var enumKey = Enum.Parse<SFXEnum>(res.name);
                SFXClipAssets.Add(enumKey, res);
            });
            await AddressableUtil.LoadWithLabel<AudioMixer>(AudioMixerAssetsTag, res =>
            {
                AudioMixers.Add(res);
            });
        }

    }
}