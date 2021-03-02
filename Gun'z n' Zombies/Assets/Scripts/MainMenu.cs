using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("PlayGame"); // loads game scene
    }

    public void QuitGame()
    {
        Debug.Log("Application Closed! Thanks for playing the game!");
        Application.Quit(); // closes the application
    }
}
