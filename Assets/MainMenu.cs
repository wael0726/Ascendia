using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadSceneAsync("SampleScene"); // Charge le jeu
        SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Additive); // Charge la UI par-dessus

    }

    public void QuitGame() {
        Application.Quit();
    }
}
