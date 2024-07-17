using Sirenix.OdinInspector;
using UnityEngine;

namespace Lucerna.Data
{
	public class GenericInformationSO : ScriptableObject 
	{
        // VARIABLES
        public string Name => genericName;
        public string Description => genericDescription;
        public Sprite IconSprite => genericSprite;

        [TitleGroup("General")]
        [Title("Sprite", horizontalLine: false)]
        [HorizontalGroup("General/H", width: 130), PreviewField(Height = 130, Alignment = ObjectFieldAlignment.Left, FilterMode = FilterMode.Point), SerializeField, HideLabel] protected Sprite genericSprite;
        [Title("Name", horizontalLine: false)]
        [VerticalGroup("General/H/V"), SerializeField, HideLabel] protected string genericName = "Default";
        [Title("Description", horizontalLine: false)]
        [VerticalGroup("General/H/V"), TextArea(5, 7), SerializeField, HideLabel] protected string genericDescription = "Default";
    }
}