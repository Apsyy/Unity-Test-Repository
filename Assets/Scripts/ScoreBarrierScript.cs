using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBarrierScript : MonoBehaviour
{
    public int score;
    public int highScore;
    

    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            score++;
        }

        if (score > PlayerPrefs.GetInt("HighScore", score))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = PlayerPrefs.GetInt("HighScore", 0);
        }
    }
}
