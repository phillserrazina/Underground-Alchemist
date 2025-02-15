using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Sirenix.OdinInspector;

using PJ.Data;
using PJ.Managers;

namespace PJ.UI
{
	public class RecipeUI : MonoBehaviour 
	{
		// VARIABLES
		[Title("References")]
		[SerializeField] private TMP_Text recipeNameText;
		[SerializeField] private TMP_Text ingredientsText;
		[SerializeField] private TMP_Text ownedAmountText;
		[SerializeField] private Button craftButton;

        [Title("Debug")]
		[SerializeField] private bool useDebugData = false;
		[SerializeField, ShowIf("useDebugData")] private RecipeSO debugData = null;

		private RecipeSO currentRecipe;

        // EXECUTION FUNCTIONS
        private void Start()
        {
            if (useDebugData)
			{
				UpdateInformation(debugData);
			}

            PlayerInventoryManager.Instance.OnInventoryChanged += PlayerInventory_OnInventoryChanged;
        }

        private void PlayerInventory_OnInventoryChanged(System.Collections.Generic.Dictionary<ItemSO, int> dictionary)
        {
			if (currentRecipe == null)
			{
				return;
			}

			UpdateInformation(currentRecipe);
        }

        // METHODS
		public void CraftButton()
		{
            foreach (var ingredient in currentRecipe.Ingredients)
            {
				PlayerInventoryManager.Instance.RemoveItem(ingredient);
            }

			PlayerInventoryManager.Instance.AddItem(currentRecipe.Result);
        }

        public void UpdateInformation(RecipeSO recipe)
		{
			currentRecipe = recipe;

			recipeNameText.text = recipe.Name;
			ingredientsText.text = GetIngredientsText(recipe);
			ownedAmountText.text = "Owned: " + PlayerInventoryManager.Instance.GetItemAmount(recipe.Result);

			craftButton.interactable = PlayerInventoryManager.Instance.CanCraftRecipe(recipe);
		}

		private string GetIngredientsText(RecipeSO recipe)
		{
			string result = "";

			foreach (var ingredient in recipe.Ingredients)
			{
				result += "- " + ingredient.Name + " (Owned: " + PlayerInventoryManager.Instance.GetItemAmount(ingredient) + ");\n";
			}

			return result;
		}
    }
}