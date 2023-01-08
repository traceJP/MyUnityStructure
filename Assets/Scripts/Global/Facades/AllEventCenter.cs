using System;
using Models;

namespace Facades
{
    /// <summary>
    /// 虽然叫 Event
    /// 但是其本质不是事件
    /// 它只是一个静态类 供业务层中间进行通信使用
    /// </summary>
    public class AllEventCenter
    {

        // 数据结构事件

        // StartGameEvent getter/setter
        public static StartGameEvent StartGameEvent { get; private set; }
        public static void SetStartGameEvent(StartGameEvent ev) => StartGameEvent = ev;

        public static void Ctor()
        {
            StartGameEvent = new StartGameEvent();
        }


    }
}