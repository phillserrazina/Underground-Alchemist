using UnityEngine;
using TMPro;

using PJ.Managers;

namespace PJ.UI
{
	public class FootbarUI : MonoBehaviour 
	{
        // VARIABLES
        [SerializeField] private TMP_Text moneyText;
        [SerializeField] private TMP_Text craftingBookButtonText;

        // EXECUTION FUNCTIONS
        private void Awake()
        {
            var inventory = FindObjectOfType<PlayerInventoryManager>();

            inventory.OnInitialized += PlayerInventory_OnInitialized;
            inventory.OnMoneyChanged += PlayerInventory_OnMoneyChanged;
        }

        // METHODS
        public void CraftingBookButton()
        {
            CraftingBookUI.Instance.TriggerBook();
            craftingBookButtonText.text = CraftingBookUI.Instance.IsCurrentlyShowing ? "Close Book" : "Crafting Book";
        }
        
        private void UpdateMoneyText(int amount)
        {
            moneyText.text = "Sludgebucks: " + amount + "\n";
        }

        // CALLBACKS
        private void PlayerInventory_OnInitialized()
        {
            UpdateMoneyText(PlayerInventoryManager.Instance.CurrentMoneyOwned);
        }

        private void PlayerInventory_OnMoneyChanged(int currentMoney)
        {
            UpdateMoneyText(currentMoney);
        }
    }
}