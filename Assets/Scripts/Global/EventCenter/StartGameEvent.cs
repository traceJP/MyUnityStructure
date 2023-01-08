namespace Models    // 参数bean是属于Models层的
{
    /// <summary>
    /// ALlEventCenter事件中心 传递的参数bean， 它只是一个包装了属性的对象 供事件的参数传递调用
    /// </summary>
    public class StartGameEvent
    {

        // 是否触发开始游戏
        public bool IsTrigger { get; private set; }

        public void SetIsTrigger(bool isTrigger) => IsTrigger = isTrigger;
        
        // 其他参数
        public int Chapter;
        public int Level;


    }
}