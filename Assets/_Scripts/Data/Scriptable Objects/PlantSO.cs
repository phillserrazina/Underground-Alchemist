using UnityEngine;

using PJ.Utils;
using PJ.Environment;

using Sirenix.OdinInspector;

namespace PJ.Data
{
	[CreateAssetMenu(menuName = "Potion Dealer/Plant")]
	public class PlantSO : ScriptableObject 
	{
		// VARIABLES
		public string Name => plantName;
		public float GrowthRate => growthRate;
		public ItemSO[] HarvestProducts => harvestProducts;
		public SpritesheetAnimation GetAnimationWithIndex(int index) => animations[index];
        
		[SerializeField] private string plantName = "";
        [SerializeField, Range(0.1f, 5f)] private float growthRate = 1f;

        [Title("Harvest Products")]
        [SerializeField] private ItemSO[] harvestProducts;

		[Title("Animations")]
        [SerializeField] private SpritesheetAnimation[] animations = new SpritesheetAnimation[4];

		// METHODS
        public bool MeetsConditionsToGrow(Vase vase)
		{
			return true;
		}
	}
}