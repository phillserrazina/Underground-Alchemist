using UnityEngine;

using PJ.Data;
using PJ.Managers;

namespace PJ.UI
{
	public class OrderButtonUI : MonoBehaviour 
	{
		// VARIABLES
		public Order AssignedOrder { get; private set; }
	
		// METHODS
		public void Initialize(Order order)
		{
			AssignedOrder = order;
		}

		public void OnClick()
		{
			LetterManager.Instance.OpenOrder(AssignedOrder);
		}
	}
}