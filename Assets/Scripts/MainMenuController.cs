using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // This method is called when the "Play" button in the main menu is clicked.
    public void PlayGame()
    {
        // Get the index of the selected character by parsing the name of the clicked button.
        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        // Set the selected character's index in the GameManager.
        GameManager.instance.CharIndex = selectedCharacter;

        // Load the "Game Play" scene to start the game.
        SceneManager.LoadScene("Game Play");
    }
}
