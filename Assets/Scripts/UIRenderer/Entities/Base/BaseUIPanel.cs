using UIRenderer.Enums;
using UnityEngine;

namespace UIRenderer.Entities.Base
{
    public abstract class BaseUIPanel : MonoBehaviour, IUIPanel
    {
        public abstract UITypeID TypeID { get; }
        
        public abstract UIRootLevel RootLevel { get; }

        public abstract void Init();

        // 抽象常用的UI方法 例如关闭UI，添加事件监听， 销毁事件监听等等

        public virtual void TearDown() {
            Destroy(gameObject);
        }


    }
}