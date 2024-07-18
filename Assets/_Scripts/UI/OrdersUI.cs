using UnityEngine;

using Sirenix.OdinInspector;

using PJ.Managers;

namespace PJ.UI
{
	public class OrdersUI : MonoBehaviour 
	{
		// VARIABLES
		[Title("References")]
		[SerializeField] private GameObject orderUiPrefab;
        [SerializeField] private Transform contents;

        private bool hasBeenInitialized = false;

        // EXECUTION FUNCTIONS
        private void Update()
        {
            if (hasBeenInitialized || OrdersManager.Instance == null)
            {
                return;
            }

            OrdersManager.Instance.OnOrderReceived += OrdersManager_OnOrderReceived;
            hasBeenInitialized = true;
        }

        // CALLBACKS
        private void OrdersManager_OnOrderReceived(Data.Order newOrder)
        {
            Instantiate(orderUiPrefab, contents);
        }
    }
}