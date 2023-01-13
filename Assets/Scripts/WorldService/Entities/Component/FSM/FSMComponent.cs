using System;
using System.Collections.Generic;
using UnityEngine;

namespace WorldService.Entities.Component.FSM
{
    public class FSMComponent<T> where T : Enum
    {

        private IState _currentState;

        private T _stateEnum;

        private readonly Dictionary<T, IState> _allState;

        public FSMComponent()
        {
            _allState = new Dictionary<T, IState>();
        }

        public void AddState(T stateType, IState instance)
        {
            if (!_allState.TryAdd(stateType, instance))
            {
                Debug.Log($"{stateType} cannot be added, because it already exists in the dictionary");
            }
        }

        public void ChangeState(T stateType)
        {
            if (_currentState == _allState[stateType]) return;
            _currentState?.OnEnter();
            _currentState = _allState[stateType];
            _currentState?.OnEnter();
        }

        public void OnTick()
        {
            _currentState?.OnTick();
        }

        public void OnFixedTick()
        {
            _currentState?.OnFixedTick();
        }

    }
}