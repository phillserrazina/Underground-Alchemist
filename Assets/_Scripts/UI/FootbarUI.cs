using UnityEngine;
using TMPro;

using PJ.Managers;

namespace PJ.UI
{
	public class FootbarUI : MonoBehaviour 
	{
        // VARIABLES
        [SerializeField] private TMP_Text moneyText;

        // EXECUTION FUNCTIONS
        private void Awake()
        {
            var inventory = FindObjectOfType<PlayerInventory>();

            inventory.OnInitialized += PlayerInventory_OnInitialized;
            inventory.OnMoneyChanged += PlayerInventory_OnMoneyChanged;
        }

        // METHODS
        public void CraftingBookButton()
        {
            CraftingBookUI.Instance.TriggerBook();
        }
        
        private void UpdateMoneyText(int amount)
        {
            moneyText.text = "Sludgebucks: " + amount + "\n";
        }

        // CALLBACKS
        private void PlayerInventory_OnInitialized()
        {
            UpdateMoneyText(PlayerInventory.Instance.CurrentMoneyOwned);
        }

        private void PlayerInventory_OnMoneyChanged(int currentMoney)
        {
            UpdateMoneyText(currentMoney);
        }
    }
}