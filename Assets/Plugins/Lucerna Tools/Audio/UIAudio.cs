using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Lucerna.Audio
{
    public class UIAudio : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        // VARIABLES
        [SerializeField] private AudioSourceExtension hoverAudioSource;
        [SerializeField] private AudioSourceExtension clickAudioSource;

        private Button button;

        // CALLBACKS
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (button == null)
            {
                button = GetComponent<Button>();
            }

            if (button == null || !button.interactable)
            {
                return;
            }

            if (hoverAudioSource != null)
            {
                hoverAudioSource.Play();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (button == null)
            {
                button = GetComponent<Button>();
            }

            if (button == null || !button.interactable)
            {
                return;
            }

            if (clickAudioSource != null)
            {
                clickAudioSource.Play();
            }
        }
    }
}