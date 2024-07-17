using UnityEngine;

using Sirenix.OdinInspector;

using Lucerna.Data;

namespace PJ.Data
{
    [CreateAssetMenu(menuName = "Potion Dealer/Recipe")]
    public class RecipeSO : GenericInformationSO 
	{
		// VARIABLES
		public ItemSO[] Ingredients => ingredients;
		public ItemSO Result => result;
		
		[Title("Ingredients")]
		[SerializeField] private ItemSO[] ingredients;

		[Title("Result")]
		[SerializeField] private ItemSO result;
	}
}