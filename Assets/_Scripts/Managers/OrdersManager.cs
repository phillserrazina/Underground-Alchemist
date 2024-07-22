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

        private List<Order> currentOrders = new();

		public event Action<Order> OnOrderReceived;
		public event Action<Order> OnOrderCompleted;

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

        public void CompleteOrder(Order orderToComplete)
        {
            currentOrders.Remove(orderToComplete);
            OnOrderCompleted?.Invoke(orderToComplete);
        }
    }
}