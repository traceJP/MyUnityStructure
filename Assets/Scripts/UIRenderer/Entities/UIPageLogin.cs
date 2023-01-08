using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIRenderer.Entities
{
    
    
    /// <summary>
    /// 用户界面
    /// 只做两件事：
    /// 1.把用户的输入反馈出去
    /// 2.显示用户操作的结果
    ///
    /// --- 绝对不做业务的逻辑处理
    /// </summary>
    public class UIPageLogin : MonoBehaviour
    {

        public Button startGameButton;


        public event Action OnStartGameHandle; 
        
        
        public void Init()
        {
            startGameButton.onClick.AddListener(() =>
            {
                // 显示按钮之类的。
                // 不要做生成角色等业务操作
                
                // 1 把开始游戏的事件抛出 （反馈）
                OnStartGameHandle?.Invoke();
                
            });
        }


    }
}