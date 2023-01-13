using UnityEngine;

namespace WorldService.Entities.Component.FSM
{
    public abstract class StateBase : IState
    {

        protected Animator Anim;

        public void Inject(Animator animator)
        {
            Anim = animator;
        }
        
        public abstract void OnEnter();

        public abstract void OnExit();

        public abstract void OnTick();

        public abstract void OnFixedTick();
        
    }
}