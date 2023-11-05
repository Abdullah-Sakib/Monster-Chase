using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // A static reference to the GameManager instance, making it accessible from other scripts.
    public static GameManager instance;

    [SerializeField]
    private GameObject[] characters; // An array of character prefabs to choose from.

    private int _charIndex; // The selected character's index.
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {
        // Ensure that there's only one instance of the GameManager throughout the game.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent the GameManager from being destroyed when changing scenes.
        }
        else
        {
            Destroy(gameObject); // Destroy any additional GameManager instances.
        }
    }

    private void OnEnable()
    {
        // Subscribe to the sceneLoaded event to perform actions when a new scene is loaded.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event when this script is disabled or destroyed.
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        // If the current scene is "Game Play," instantiate the selected character.
        if (scene.name == "Game Play")
        {
            Instantiate(characters[_charIndex]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code can be placed here if needed.
    }

    // Update is called once per frame
    void Update()
    {
        // Game management or update logic can be added here if necessary.
    }
}
