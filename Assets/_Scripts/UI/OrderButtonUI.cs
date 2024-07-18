using PJ.Data;
using PJ.Managers;
using UnityEngine;

namespace PJ.UI
{
	public class OrderButtonUI : MonoBehaviour 
	{
		// VARIABLES
		private Order assignedOrder;
	
		// EXECUTION FUNCTIONS
	
		// METHODS
		public void Initialize(Order order)
		{
			assignedOrder = order;
		}

		public void OnClick()
		{
			LetterManager.Instance.OpenOrder(assignedOrder);
		}
		
		// CALLBACKS
	}
}