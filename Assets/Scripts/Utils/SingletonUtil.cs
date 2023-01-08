using UnityEngine;

namespace Utils
{
    public class SingletonUtil<T> : MonoBehaviour where T : SingletonUtil<T>
    {

        private static T _mInstance;
        
        public static T Instance => _mInstance;

        protected virtual void Awake()
        {

            if (_mInstance == null)
            {

                _mInstance = (T)this;

            }

        }

    }
}