using Audio;
using GameEvent;
using Input;
using UIRenderer;

namespace Facades
{
    public static class AllManager
    {
        public static UIManager UIManager { get; private set; }
        
        public static AudioManager AudioManager { get; private set; }
        
        public static EventManager EventManager { get; private set; }
        
        public static InputManager InputManager { get; private set; }

        
        public static void Ctor()
        {
            UIManager = new UIManager();
            AudioManager = new AudioManager();
            EventManager = new EventManager();
            InputManager = new InputManager();
        }
        
    }
}