using Lucerna.Common.Singletons;
using UnityEngine;

namespace PJ.Managers
{
	public class TimeManager : Singleton<TimeManager> 
	{
        // VARIABLES
        [SerializeField] private float dayDuration = 120f;

        private float currentTime = 0f;

        public float CurrentDayPercentage => currentTime / dayDuration;

        // EXECUTION FUNCTIONS
        private void Update()
        {
            currentTime += Time.deltaTime;

            if (currentTime > dayDuration)
            {
                currentTime = 0f;
            }
        }

        // METHODS

        // CALLBACKS
    }
}