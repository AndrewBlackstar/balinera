using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    // Nombres de las escenas del juego
    [Header("Scene Names")]
    public string firstLevelScene = "Bogota race";        // Escena para "Nuevo Juego"
    public string raceSelectScene = "Selection"; // Escena para selección de pista

    // ===== BOTONES =====

    // Nuevo juego
    public void NewGame()
    {
        // Elimina progreso anterior
        PlayerPrefs.DeleteKey("LastScene");
        PlayerPrefs.Save();

        // Cargar primera escena del juego
        SceneManager.LoadScene(firstLevelScene);
    }

    // Continuar juego
    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("LastScene"))
        {
            string lastScene = PlayerPrefs.GetString("LastScene");
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            Debug.Log("No hay partida guardada. Iniciando nuevo juego...");
            SceneManager.LoadScene(firstLevelScene);
        }
    }

    // Selección de carrera (pistas)
    public void SelectRace()
    {
        SceneManager.LoadScene(raceSelectScene);
    }

    // Salir del juego
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    // ===== GUARDADO SIMPLE =====
    // Llamar este método desde el juego al cambiar de escena
    public static void SaveProgress(string sceneName)
    {
        PlayerPrefs.SetString("LastScene", sceneName);
        PlayerPrefs.Save();
    }
    public void LoadScene(string Name)
    { // Load the scene with the specified name
      UnityEngine.SceneManagement.SceneManager.LoadScene(Name);
    }

    }
