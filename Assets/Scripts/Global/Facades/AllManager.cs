using UIRenderer;

namespace Global.Facades
{
    public static class AllManager
    {
        
        public static UIManager UIManager { get; private set; }
        public static void SetUIManager(UIManager uiManager) => UIManager = uiManager;

        
        public static void Ctor()
        {
            UIManager = null;
        }
        
    }
}