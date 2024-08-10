using System.Linq;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

using PJ.Managers;

namespace PJ.UI
{
	public class OrdersUI : MonoBehaviour 
	{
		// VARIABLES
		[Title("References")]
		[SerializeField] private OrderButtonUI orderUiPrefab;
        [SerializeField] private Transform contents;

        private List<OrderButtonUI> spawnedOrderUIs = new();

        private bool hasBeenInitialized = false;

        // EXECUTION FUNCTIONS
        private void Update()
        {
            if (hasBeenInitialized || OrdersManager.Instance == null)
            {
                return;
            }

            OrdersManager.Instance.OnOrderReceived += OrdersManager_OnOrderReceived;
            OrdersManager.Instance.OnOrderCompleted += OrdersManager_OnOrderCompleted;

            hasBeenInitialized = true;
        }

        // CALLBACKS
        private void OrdersManager_OnOrderReceived(Data.Order newOrder)
        {
            var spawnedOrderUI = Instantiate(orderUiPrefab, contents);
            spawnedOrderUI.Initialize(newOrder);
            spawnedOrderUIs.Add(spawnedOrderUI);
        }

        private void OrdersManager_OnOrderCompleted(Data.Order completedOrder)
        {
            var targetOrderUI = spawnedOrderUIs.FirstOrDefault(orderUI => orderUI.AssignedOrder == completedOrder);

            spawnedOrderUIs.Remove(targetOrderUI);
            Destroy(targetOrderUI.gameObject);
        }
    }
}