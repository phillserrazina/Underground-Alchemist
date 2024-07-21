using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace PJ.Managers
{
	public class LightHandler : MonoBehaviour
	{
        // VARIABLES
        [SerializeField] private Light2D targetLight;
		[SerializeField] private Gradient lightGradient;

        // METHODS
        private void Update()
        {
            if (TimeManager.Instance == null)
            {
                return;
            }

            targetLight.color = lightGradient.Evaluate(TimeManager.Instance.CurrentDayPercentage);
        }
    }
}