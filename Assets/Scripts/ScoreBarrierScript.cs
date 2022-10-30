using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBarrierScript : MonoBehaviour
{
    public int score;

    private void Start()
    {
        score = 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("obstacle"))
        {
            score++;
        }
    }
}
