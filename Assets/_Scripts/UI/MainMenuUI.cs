using Lucerna.Utils;
using UnityEngine;

namespace PJ.UI
{
	public class MainMenuUI : MonoBehaviour 
	{
		// VARIABLES
	
		// EXECUTION FUNCTIONS
	
		// METHODS
		public void PlayButton()
		{
			SceneLoader.Instance.LoadGameplayScene("Environment");
		}
		
		// CALLBACKS
	}
}