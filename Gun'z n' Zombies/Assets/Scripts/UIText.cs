using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    public Text zombieNumUI;
    private int zombieNum = 10;

    public Text scoreUI;
    public int score;

    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        scoreUI.text = "SCORE: " + score;
        zombieNumUI.text = "x " + zombieNum;
    }

    public void AddScore()
    {
        zombieNum--;
        score += 100;

        scoreUI.text = "SCORE: " + score;
        zombieNumUI.text = "x " + zombieNum;

        if (zombieNum == 0)
        {
            ScoreMenu.finalscorestr = "SCORE: " + score;
            Destroy(wall);
        }
    }
}
