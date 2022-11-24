using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBarrierScript : MonoBehaviour
{
    public int score;
    public int highScore;
    public bool isNewHighScore;

    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("highscore", 0);
        isNewHighScore = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // increase score when obstacle passes player
        if (collision.gameObject.CompareTag("obstacle"))
        {
            score++;
        }

        // update highscore if player score is greater than current highscore
        if (score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", score);
            highScore = PlayerPrefs.GetInt("highscore", 0);
            isNewHighScore = true;
            Debug.Log(highScore);
        }
    }
}
