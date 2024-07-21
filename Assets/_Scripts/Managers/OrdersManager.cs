using System;
using System.Collections.Generic;

using UnityEngine;

using Lucerna.Common.Singletons;

using PJ.Data;

namespace PJ.Managers
{
	public class OrdersManager : Singleton<OrdersManager> 
	{
		// VARIABLES
		[SerializeField] private float orderRate = 5f;

		private float currentOrderTimer = 0f;

		public event Action<Order> OnOrderReceived;

        private List<Order> currentOrders = new();

        // EXECUTION FUNCTIONS
        private void Start()
        {
            currentOrderTimer = orderRate;
        }

        private void Update()
        {
            currentOrderTimer -= Time.deltaTime;

            if (currentOrderTimer <= 0f)
            {
                ReceiveOrder();
            }
        }

        // METHODS
        private void ReceiveOrder()
        {
            Order newOrder = new Order.Builder().Build();
            currentOrders.Add(newOrder);
            
            OnOrderReceived?.Invoke(newOrder);

            currentOrderTimer = orderRate;
        }
    }
}