using UnityEngine;
using TMPro;

using PJ.Managers;

namespace PJ.UI
{
	public class PlayerInventoryUI : MonoBehaviour 
	{
		// VARIABLES

        // EXECUTION FUNCTIONS
        private void Awake()
        {
            var inventory = FindObjectOfType<PlayerInventory>();
        }

        // CALLBACKS
    }
}