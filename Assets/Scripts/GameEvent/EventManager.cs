using System;
using System.Collections.Generic;
using GameEvent.Entities;

namespace GameEvent
{
    public class EventManager
    {
        private Dictionary<Type, Action<IGameEvent>> _events;

        private Dictionary<Delegate, Action<IGameEvent>> _eventLookups;
        
        public void Init()
        {
            _events = new Dictionary<Type, Action<IGameEvent>>();
            _eventLookups = new Dictionary<Delegate, Action<IGameEvent>>();
        }

        public void AddListener<T>(Action<T> evt) where T : IGameEvent
        {
            if (!_eventLookups.ContainsKey(evt))
            {
                Action<IGameEvent> newAction = (e) => evt((T) e);
                _eventLookups[evt] = newAction;
                if (_events.TryGetValue(typeof(T), out var internalAction))
                {
                    _events[typeof(T)] = internalAction += newAction;
                }
                else
                {
                    _events[typeof(T)] = newAction;
                }
            }
        }

        public void RemoveListener<T>(Action<T> evt) where T : IGameEvent
        {
            if (_eventLookups.TryGetValue(evt, out var action))
            {
                if (_events.TryGetValue(typeof(T), out var tempAction))
                {
                    tempAction -= action;
                    if (tempAction == null)
                    {
                        _events.Remove(typeof(T));
                    }
                    else
                    {
                        _events[typeof(T)] = tempAction;
                    }
                }
                _eventLookups.Remove(evt);
            }
        }

        public void Broadcast(IGameEvent evt)
        {
            if (_events.TryGetValue(evt.GetType(), out var action))
            {
                action.Invoke(evt);
            }
        }

        public void Clear()
        {
            _events.Clear();
            _eventLookups.Clear();
        }
        
    }
}