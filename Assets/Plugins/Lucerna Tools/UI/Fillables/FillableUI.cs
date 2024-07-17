using UnityEngine;
using UnityEngine.UI;
// using MoreMountains.Feedbacks;
using Lucerna.Audio;

namespace Lucerna.UI
{
	public class FillableUI : MonoBehaviour 
	{
		// VARIABLES
		[SerializeField] private Image fillImage;
		// [SerializeField] private MMF_Player feedbacks;
        [SerializeField] private float fillSpeed = 1f;
		[SerializeField] private AudioSourceExtension popAudioSource;

		private float currentPercentage = 0f;

		public bool IsDoneAnimating => fillImage.fillAmount == currentPercentage;

		private bool hasPopped = false;

        // EXECUTION FUNCTIONS
        private void Update()
        {
            fillImage.fillAmount = Mathf.MoveTowards(fillImage.fillAmount, currentPercentage, Time.unscaledDeltaTime * fillSpeed);

			if (fillImage.fillAmount >= 1f && !hasPopped)
			{
				hasPopped = true;
				// feedbacks.PlayFeedbacks();
				popAudioSource.Play();
			}
        }

        // METHODS
        public void UpdateFill(float percentage)
		{
			currentPercentage = percentage;
		}

		public void UpdateFillInstant(float percentage)
		{
			currentPercentage = percentage;
			fillImage.fillAmount = currentPercentage;

			if (percentage == 1f)
			{
				hasPopped = true;
			}
		}
	}
}