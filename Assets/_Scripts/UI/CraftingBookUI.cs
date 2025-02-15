using UnityEngine;

using DG.Tweening;
using Sirenix.OdinInspector;

using Lucerna.Common.Singletons;
using PJ.Managers;

namespace PJ.UI
{
	public class CraftingBookUI : Singleton<CraftingBookUI> 
	{
		// VARIABLES
		[Title("References")]
		[SerializeField] private Transform contents;

		[Title("Settings")]
		[SerializeField] private float showPositionY = 30f;
		[SerializeField] private float hidePositionY = -1000f;

        public bool IsCurrentlyShowing { get; private set; } = false;

        private float currentTriggerCooldown = 0f;

        // EXECUTION FUNCTIONS
        protected override void Awake()
        {
            base.Awake();

            Vector3 newPosition = contents.position;
            newPosition.y = hidePositionY;
            contents.position = newPosition;
        }

        private void Update()
        {
            currentTriggerCooldown -= Time.deltaTime;
        }

        // METHODS
        public void TriggerBook()
        {
            contents.gameObject.SetActive(true);

            if (currentTriggerCooldown > 0f)
            {
                return;
            }

            float triggerCooldown = 0.25f;

            IsCurrentlyShowing = !IsCurrentlyShowing;
            contents.DOLocalMoveY(IsCurrentlyShowing ? showPositionY : hidePositionY, triggerCooldown);
            currentTriggerCooldown = triggerCooldown;

            FindObjectOfType<LetterUI>().CloseLetter();
        }
    }
}