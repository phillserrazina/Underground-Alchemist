using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        [SerializeField] private Button deliverButton;

        [Space(5)]
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text descriptionText;

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

            descriptionText.text = "Description" + "\n\n";

            descriptionText.text += "----- ORDER -----\n";

            bool valid = true;

            foreach (var pair in order.OrderedItems)
            {
                descriptionText.text += "- " + pair.Key.Name + " x" + pair.Value + ";\n";

                if (PlayerInventoryManager.Instance.GetItemAmount(pair.Key) < pair.Value)
                {
                    valid = false;
                }
            }

            deliverButton.interactable = valid;

            contents.gameObject.SetActive(true);
            contents.DOLocalMoveY(showPositionY, 0.25f);
            currentOrder = order;
        }

        public void CloseLetter()
        {
            contents.DOLocalMoveY(hidePositionY, 0.25f);
            DOVirtual.DelayedCall(0.25f, () => { currentOrder = null; });
        }

        public void DeliverButton()
        {
            OrdersManager.Instance.CompleteOrder(currentOrder);

            PlayerInventoryManager.Instance.AddMoney(100);

            CloseLetter();
            currentOrder = null;
        }

        // CALLBACKS
        private void LetterManager_OnOrderOpened(Order openedOrder)
        {
            OpenLetter(openedOrder);
        }
    }
}