using UnityEngine;
using TMPro;

using PJ.Data;
using PJ.Environment;

namespace PJ.UI
{
	public class PlantButtonUI : MonoBehaviour 
	{
        // VARIABLES
        [SerializeField] private TMP_Text buttonText;
        [SerializeField] private PlantSO plantData;

        // EXECUTION FUNCTIONS
        private void Start()
        {
            buttonText.text = plantData.Name;
        }

        // METHODS
        public void OnClick()
        {
            GetComponentInParent<FarmSpot>().ActivateVaseWithPlant(plantData);
        }
    }
}