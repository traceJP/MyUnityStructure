using System.Threading.Tasks;
using Global.Facades;
using UnityEngine;

namespace Global.Controller
{
    public class MainController
    {

        public void Ctor() { }

        public void Inject(Canvas canvas, AudioSource globalSource)
        {
            AllManager.UIManager.Inject(canvas);
            AllManager.AudioManager.Inject(globalSource);
        }
        
        public async Task Init()
        {
            // 管理器 Init
            await AllManager.UIManager.Init();
            await AllManager.AudioManager.Init();
            AllManager.EventManager.Init();
        }

    }
}