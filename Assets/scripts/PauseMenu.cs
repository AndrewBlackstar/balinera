using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        // Reanudar el tiempo
        Time.timeScale = 1f;

        // Cerrar la escena del menú de pausa
        SceneManager.UnloadSceneAsync("PauseMenu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToOptions()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void OnEnable()
    {
        // Pausar el juego automáticamente al cargar esta escena
        Time.timeScale = 0f;
    }
}
