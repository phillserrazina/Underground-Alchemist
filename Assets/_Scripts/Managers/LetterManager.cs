using System;

using UnityEngine;

using Lucerna.Common.Singletons;

using PJ.Data;

namespace PJ.Managers
{
	public class LetterManager : Singleton<LetterManager> 
	{
		// VARIABLES
		private Order currentlyOpenOrder;

		public event Action<Order> OnOrderOpened;
	
		// METHODS
		public void OpenOrder(Order orderToBeOpened)
		{
			currentlyOpenOrder = orderToBeOpened;

			OnOrderOpened?.Invoke(orderToBeOpened);
		}
	}
}