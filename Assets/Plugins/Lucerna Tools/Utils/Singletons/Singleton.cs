using UnityEngine;

namespace Lucerna.Common.Singletons
{
	public class Singleton<T> : MonoBehaviour where T : Component
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

			Instance = this as T;
        }

        // CALLBACKS
    }
}