using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoadingScreen : MonoBehaviour
{
    private Slider loadingSlider; // Reference to the UI slider for progress
    private Label loadingText;    // Reference to the UI text for progress percentage
    public UIDocument uiDocument;
    public string Game;  // Name of the scene to load

    void Start()
    {
        // Start the loading process in a coroutine to allow UI updates
        loadingSlider = uiDocument.rootVisualElement.Q<Slider>("LoadingSlider");
        loadingText = uiDocument.rootVisualElement.Q<Label>("LoadingButton");
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(Game);

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f); // Normalize progress

            // Update UI elements
            loadingSlider.value = progress;
            loadingText.text = $"Loading: {Mathf.Round(progress * 100)}%";

            yield return null; // Wait for the next frame
        }
    }
}