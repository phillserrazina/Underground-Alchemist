using UnityEngine;

using DG.Tweening;
using Sirenix.OdinInspector;

using PJ.Data;
using PJ.Managers;

namespace PJ.UI
{
	public class LetterUI : MonoBehaviour 
	{
        // VARIABLES
        [Title("References")]
        [SerializeField] private Transform contents;

        [Title("Settings")]
        [SerializeField] private float showPositionY = 30f;
        [SerializeField] private float hidePositionY = -1000f;

        private bool hasBeenInitialized = false;
        private Order currentOrder = null;

        // EXECUTION FUNCTIONS
        private void Awake()
        {
            Vector3 newPosition = contents.position;
            newPosition.y = hidePositionY;
            contents.position = newPosition;
        }

        private void Update()
        {
            if (hasBeenInitialized || LetterManager.Instance == null)
			{
				return;
			}

            LetterManager.Instance.OnOrderOpened += LetterManager_OnOrderOpened;
			hasBeenInitialized = true;
        }

        // METHODS
        private void OpenLetter(Order order)
		{
            if (currentOrder != null)
            {
                return;
            }

            contents.gameObject.SetActive(true);
            contents.DOLocalMoveY(showPositionY, 0.25f);
            currentOrder = order;
        }

        public void CloseLetter()
        {
            contents.DOLocalMoveY(hidePositionY, 0.25f);
            DOVirtual.DelayedCall(0.25f, () => { currentOrder = null; });
        }

        // CALLBACKS
        private void LetterManager_OnOrderOpened(Order openedOrder)
        {
            OpenLetter(openedOrder);
        }
    }
}