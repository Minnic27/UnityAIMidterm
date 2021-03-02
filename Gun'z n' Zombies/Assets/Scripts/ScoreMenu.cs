using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    public static string resulttextstr;
    public Text ResultText;

    public static string finalscorestr;
    public Text FinalScore;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        ResultText.text = resulttextstr;
        FinalScore.text = finalscorestr;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("PlayGame"); // loads game scene
    }

    public void ReturntoMenu()
    {
        SceneManager.LoadScene("MainMenu"); // return to MainMenu scene
    }
}
