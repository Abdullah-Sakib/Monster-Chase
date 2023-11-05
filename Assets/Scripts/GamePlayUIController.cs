using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour
{
    // This method is called when the "Restart" button is clicked in the game.
    public void RestartGame()
    {
        // Restart the game by loading the current active scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // This method is called when the "Home" button is clicked in the game.
    public void HomeButton()
    {
        // Return to the main menu scene.
        SceneManager.LoadScene("MainMenu");
    }
}
