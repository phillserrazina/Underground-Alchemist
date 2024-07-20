using UnityEngine;

using PJ.Data;
using PJ.Utils;
using PJ.Managers;

namespace PJ.Environment
{
    public class Vase : MonoBehaviour
    {
        // VARIABLES
        [SerializeField] private Canvas harvestCanvas;
        [SerializeField] private SpritesheetAnimator animator;

        private PlantSO plantData;

        private float currentPlantGrowth = 0f;

        // EXECUTION FUNCTIONS
        private void Update()
        {
            if (plantData.MeetsConditionsToGrow(this))
            {
                currentPlantGrowth += Time.deltaTime * plantData.GrowthRate;

                currentPlantGrowth = Mathf.Clamp(currentPlantGrowth, 0f, 100f);

                int animationIndex = 0;

                if (currentPlantGrowth >= 75f)
                {
                    animationIndex = 3;

                    if (!harvestCanvas.gameObject.activeSelf)
                    {
                        harvestCanvas.gameObject.SetActive(true);
                    }
                }
                else if (currentPlantGrowth >= 50f)
                {
                    animationIndex = 2;
                }
                else if (currentPlantGrowth >= 25f)
                {
                    animationIndex = 1;
                }

                animator.PlayAnimation(plantData.GetAnimationWithIndex(animationIndex));
            }
            else
            {
                animator.StopAnimation();
            }
        }

        public void Harvest()
        {
            currentPlantGrowth = 0f;

            foreach (var product in plantData.HarvestProducts)
            {
                PlayerInventoryManager.Instance.AddItem(product);
            }

            harvestCanvas.gameObject.SetActive(false);
        }

        // METHODS
        public void Initialize(PlantSO plantData)
        {
            this.plantData = plantData;
            animator.PlayAnimation(plantData.GetAnimationWithIndex(0));
        }
    }
}