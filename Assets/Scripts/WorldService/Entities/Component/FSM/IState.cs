namespace WorldService.Entities.Component.FSM
{
    public interface IState
    {

        public void OnEnter();

        public void OnExit();

        public void OnTick();

        public void OnFixedTick();

    }
}