using System.Collections;

using UnityEngine;

using Sirenix.OdinInspector;

namespace PJ.Utils
{
	public class SpritesheetAnimator : MonoBehaviour 
	{
		// VARIABLES
		[Title("References")]
		[SerializeField] private SpriteRenderer targetSpriteRenderer;

        [Title("Settings")]
        [SerializeField] private int frameRate = 30;

		private Coroutine currentAnimationCoroutine;
		private SpritesheetAnimation currentAnimation;

        // METHODS
        public void PlayAnimation(SpritesheetAnimation targetAnimation)
		{
			if (currentAnimationCoroutine != null && targetAnimation.Spritesheet[0].name == currentAnimation.Spritesheet[0].name)
			{
				return;
			}

			StopAnimation();
			currentAnimation = targetAnimation;
			currentAnimationCoroutine = StartCoroutine(PlayAnimationCoroutine(targetAnimation));
			Debug.Log("Start new animation!");
        }

		public void StopAnimation()
		{
			if (currentAnimationCoroutine == null)
			{
				return;
			}

			StopCoroutine(currentAnimationCoroutine);
			currentAnimationCoroutine = null;
		}
		
		private IEnumerator PlayAnimationCoroutine(SpritesheetAnimation targetAnimation)
		{
			targetSpriteRenderer.sprite = targetAnimation.GetNextSprite();
            yield return new WaitForSeconds(1f / frameRate);
            currentAnimationCoroutine = StartCoroutine(PlayAnimationCoroutine(targetAnimation));
		}

		// CALLBACKS
	}

	[System.Serializable]
	public class SpritesheetAnimation
	{
		// VARIABLES
		[SerializeField] private Sprite[] spritesheet;

		public Sprite[] Spritesheet => spritesheet;

		private int currentSpriteIndex = -1;

		// METHODS
		public Sprite GetNextSprite()
		{
			currentSpriteIndex++;

			if (currentSpriteIndex >= spritesheet.Length) currentSpriteIndex = 0;

			return spritesheet[currentSpriteIndex];
		}
	}
}