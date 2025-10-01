using UnityEngine;

public class ExitApplication : MonoBehaviour
{
    // Call this from a UI button
    public void QuitGame()
    {
        // Works in a built game
        Application.Quit();

        // Only for debugging in the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
