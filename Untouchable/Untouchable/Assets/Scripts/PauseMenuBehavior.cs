using UnityEngine;

public class PauseMenuBehavior : MainMenuBehavior
{
    // Bool to check if the game is paused 
    public static bool isPaused;

    // Repository for the pause menu
    [Tooltip("A reference to the pause menu object")]
    public GameObject pauseMenu;
    void Start()
    {
        // The game is not paused 
        isPaused = false;

        // The Pause Menu object is inactive
        pauseMenu.SetActive(false);

        // Timescale is set to 1, meaning objects can move in the game 
        Time.timeScale = 1;
    }
    public void GamePaused()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            // Pause menu is open, go back to game 
            // if false becomes true, and vice versa 
            isPaused = true;
            pauseMenu.SetActive(true);
        }

        // If isPaused is true, set timescale to 0, freezing all movement. 
        // Else, keep timescale at 1, allowing for movement. 
        if (isPaused == true)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            isPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);

        }
    }

    void Update()
    {
        // If the escape key is pressed, activate the Pause Menu object 
        if (Input.GetKeyDown("escape"))
        {
            GamePaused();
            Debug.Log("Pausing");
        }
    }

    public void ResumeGame()
    {
        // The game is not paused 
        isPaused = false;

        // The pause menu is not active 
        pauseMenu.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Timescale is set to 1, meaning objects can move in the game 
        Time.timeScale = 1;
    }
}
