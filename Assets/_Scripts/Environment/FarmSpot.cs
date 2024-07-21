using System;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Sirenix.OdinInspector;

using PJ.Data;
using PJ.Managers;

namespace PJ.Environment
{
	public class FarmSpot : MonoBehaviour 
	{
        // VARIABLES
        [Title("References")]
        [SerializeField] private Vase vase;

        [Title("UI")]
        [SerializeField] private Canvas buyCanvas;
        [SerializeField] private Button buyButton;

        [Space(5)]
        [SerializeField] private Canvas plantSelectionCanvas;

        private int costToBuild = 10;

        // EXECUTION FUNCTIONS
        private void Awake()
        {
            var inventory = FindObjectOfType<PlayerInventoryManager>();
            inventory.OnInitialized += Inventory_OnInitialized;
            inventory.OnMoneyChanged += PlayerInventoryManager_OnMoneyChanged;
        }

        // METHODS
        public void BuySpot()
		{
            buyCanvas.gameObject.SetActive(false);
            plantSelectionCanvas.gameObject.SetActive(true);
        }

        public void HarvestSpot()
        {
            buyCanvas.gameObject.SetActive(true);

            vase.Harvest();
            vase.gameObject.SetActive(false);
        }

        public void ActivateVaseWithPlant(PlantSO plantData)
        {
            plantSelectionCanvas.gameObject.SetActive(false);

            vase.gameObject.SetActive(true);
            vase.Initialize(plantData);

            PlayerInventoryManager.Instance.RemoveMoney(costToBuild);
        }

        // CALLBACKS
        private void PlayerInventoryManager_OnMoneyChanged(int newMoneyAmount)
        {
            buyButton.interactable = newMoneyAmount >= costToBuild;
            buyButton.GetComponentInChildren<TMP_Text>().text = "Buy (" + costToBuild + "SB)";
        }

        private void Inventory_OnInitialized()
        {
            buyButton.interactable = PlayerInventoryManager.Instance.CurrentMoneyOwned >= costToBuild;
            buyButton.GetComponentInChildren<TMP_Text>().text = "Buy (" + costToBuild + "SB)";
        }
    }
}