using UIRenderer.Enums;

namespace UIRenderer
{
    public interface IUIPanel
    {
        
        public UITypeID TypeID { get; }
        
        public UIRootLevel RootLevel { get; }
        
    }
}