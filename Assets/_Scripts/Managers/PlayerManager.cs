using UnityEngine;

using UnityEngine.InputSystem;

using Sirenix.OdinInspector;
using Lucerna.Common.Singletons;

using PJ.Entities.Player.Controllers;

namespace PJ.Managers
{
	public class PlayerManager : Singleton<PlayerManager> 
	{
		// VARIABLES
		[Title("References")]
		[SerializeField] private PlayerController defaultController;

		public PlayerController CurrentController { get; private set; }

        // EXECUTION FUNCTIONS
        private void Start()
        {
			CurrentController = defaultController;
        }

		private void OnSelect(InputValue value)
		{
			if (value.isPressed)
			{
				CurrentController.OnSelect();
			}
		}
    }
}