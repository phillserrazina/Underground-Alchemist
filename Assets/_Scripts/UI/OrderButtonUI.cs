using PJ.Managers;
using UnityEngine;

namespace PJ.UI
{
	public class OrderButtonUI : MonoBehaviour 
	{
		// VARIABLES
	
		// EXECUTION FUNCTIONS
	
		// METHODS
		public void OnClick()
		{
			LetterManager.Instance.OpenOrder(null);
		}
		
		// CALLBACKS
	}
}