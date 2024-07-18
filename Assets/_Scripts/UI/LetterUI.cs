using UnityEngine;

using PJ.Data;
using PJ.Managers;

namespace PJ.UI
{
	public class LetterUI : MonoBehaviour 
	{
        // VARIABLES
        [SerializeField] private Transform contents;

		private bool hasBeenInitialized = false;

        // EXECUTION FUNCTIONS
        private void Update()
        {
            if (hasBeenInitialized || LetterManager.Instance == null)
			{
				return;
			}

            LetterManager.Instance.OnOrderOpened += LetterManager_OnOrderOpened;
			hasBeenInitialized = true;
        }

        // METHODS
        private void OpenLetter(Order order)
		{
            contents.gameObject.SetActive(true);

            Debug.Log(order.ToString());
		}

        public void CloseLetter()
        {
            contents.gameObject.SetActive(false);
        }

        // CALLBACKS
        private void LetterManager_OnOrderOpened(Order openedOrder)
        {
            OpenLetter(openedOrder);
        }
    }
}