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
        highScore = PlayerPrefs.GetInt("highscore", 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            score++;
        }

        if (score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", score);
            highScore = PlayerPrefs.GetInt("highscore", 0);
            Debug.Log(highScore);
        }
    }
}
