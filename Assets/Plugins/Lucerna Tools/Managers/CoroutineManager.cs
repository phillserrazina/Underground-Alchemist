using UnityEngine;

namespace Lucerna.Managers
{
	public class CoroutineManager : MonoBehaviour 
	{
		// VARIABLES
		public static CoroutineManager Instance { get; private set; }

        // EXECUTION FUNCTIONS
        private void Awake()
        {
            Instance = this;
        }

        // METHODS

        // CALLBACKS
    }
}