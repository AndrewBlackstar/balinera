using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string pauseSceneName = "PauseMenu";
    private bool isPauseMenuLoaded = false;

    void Update()
    {
        // Detectar tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPauseMenuLoaded)
                ShowPauseMenu();
            else
                HidePauseMenu();
        }
    }

    public void ShowPauseMenu()
    {
        if (isPauseMenuLoaded) return;

        SceneManager.LoadScene(pauseSceneName, LoadSceneMode.Additive);
        isPauseMenuLoaded = true;
    }

    public void HidePauseMenu()
    {
        if (!isPauseMenuLoaded) return;

        SceneManager.UnloadSceneAsync(pauseSceneName);
        isPauseMenuLoaded = false;
    }
}
