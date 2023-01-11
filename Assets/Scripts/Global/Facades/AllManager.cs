using Audio;
using GameEvent;
using UIRenderer;

namespace Global.Facades
{
    public static class AllManager
    {
        
        public static UIManager UIManager { get; private set; }
        public static void SetUIManager(UIManager uiManager) => UIManager = uiManager;

        public static AudioManager AudioManager { get; private set; }
        public static void SetAudioManager(AudioManager audioManager) => AudioManager = audioManager;
        
        public static EventManager EventManager { get; private set; }
        public static void SetEventManager(EventManager eventManager) => EventManager = eventManager;

        public static void Ctor()
        {
            UIManager = null;
            AudioManager = null;
            EventManager = null;
        }
        
    }
}