using UnityEngine;

namespace Lucerna.UI
{
	public class BillboardUI : MonoBehaviour 
	{
        // VARIABLES
        private Camera mainCamera;

        // EXECUTION FUNCTIONS
        private void Awake()
        {
            mainCamera = Camera.main;
            transform.forward = mainCamera.transform.forward;
        }

        private void Update()
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }

            transform.forward = mainCamera.transform.forward;
        }
    }
}