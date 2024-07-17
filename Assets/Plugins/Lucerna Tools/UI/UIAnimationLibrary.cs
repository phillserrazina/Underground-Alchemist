using UnityEngine;

namespace Lucerna.UI
{
	public class UIAnimationLibrary : MonoBehaviour 
	{
		// METHODS
		public void Deactivate()
		{
			gameObject.SetActive(false);
		}
	}
}