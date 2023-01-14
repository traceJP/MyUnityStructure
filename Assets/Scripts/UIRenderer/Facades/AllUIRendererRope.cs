using System;
using System.Collections.Generic;

namespace UIRenderer.Facades
{
    public static class AllUIRendererRope
    {
        
        private static Dictionary<Type, IUIPanel> _uiPanels;

        public static T GetUIPanels<T>() where T : class, IUIPanel
        {
            if (_uiPanels.TryGetValue(typeof(T), out var uiPanel))
            {
                return (T)uiPanel;
            }
            return null;
        }

        public static void SetUIPanels(IUIPanel uiPanel)
        {
            if (_uiPanels.ContainsKey(uiPanel.GetType()))
            {
                _uiPanels[uiPanel.GetType()] = uiPanel;
            }
            else
            {
                _uiPanels.Add(uiPanel.GetType(), uiPanel);
            }
        }

        public static void Ctor()
        {
            _uiPanels = new Dictionary<Type, IUIPanel>();
        }
        
    }
}