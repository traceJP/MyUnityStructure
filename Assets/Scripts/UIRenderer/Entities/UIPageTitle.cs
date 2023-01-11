using System;
using UIRenderer.Entities.Base;
using UIRenderer.Enums;
using UnityEngine.UI;

namespace UIRenderer.Entities
{

    public class UIPageTitle : BaseUIPanel
    {
        public override UITypeID TypeID => UITypeID.PageTitle;
        public override UIRootLevel RootLevel => UIRootLevel.Page;

 
        
        public Button startGameButton;


        public event Action OnStartGameHandle; 
        
        
        public override void Init()
        {
            startGameButton.onClick.AddListener(() =>
            {
                OnStartGameHandle?.Invoke();
                
            });
        }


    }
}