using UnityEngine;

using UnityEditor;
using UnityEditor.SceneManagement;

namespace PJ.Editor
{
	public class SceneUtilities : MonoBehaviour 
	{
        // VARIABLES

        // EXECUTION FUNCTIONS

        // METHODS
        [MenuItem("Scene/Open/Main Menu", priority = 0)]
        static void OpenMainMenuScene()
        {
            EditorSceneManager.OpenScene("Assets/_Scenes/Main Menu.unity");
        }

        [MenuItem("Scene/Open/Game Scene", priority = 100)]
        static void OpenIntroCutsceneScene()
        {
            EditorSceneManager.OpenScene("Assets/_Scenes/Environment (Static).unity", OpenSceneMode.Single);
            EditorSceneManager.OpenScene("Assets/_Scenes/Gameplay (Dynamic).unity", OpenSceneMode.Additive);
            EditorSceneManager.OpenScene("Assets/_Scenes/Gameplay UI (Dynamic).unity", OpenSceneMode.Additive);
        }

        // CALLBACKS
    }
}