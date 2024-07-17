using UnityEngine;

namespace Lucerna.Common.Singletons
{
    public class SingletonPersistent<T> : MonoBehaviour where T : Component
    {
        // VARIABLES
        public static T Instance { get; protected set; }

        // EXECUTION FUNCTIONS
        protected virtual void Awake()
        {
            InitializeSingleton();
        }

        // METHODS
        protected virtual void InitializeSingleton()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            transform.SetParent(null);

            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
        }

        // CALLBACKS
    }
}