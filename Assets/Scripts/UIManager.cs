using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject inGameUI;

    public TextMeshProUGUI[] distanceUI;
    public TextMeshProUGUI[] scoreUI;
    public TextMeshProUGUI[] highscoreUI;

    public PlayerScript player;
    public ScoreBarrierScript scoreBarrier;

    private void Update()
    {
        // for each distance ui element change its text to display the distance travelled
        for (int i = 0; i < distanceUI.Length; i++)
        {
            distanceUI[i].text = "Distance: " + player.distance.ToString("F0") + "m";
        }
        // for each score ui element change its text to display players current score
        for (int i = 0; i < scoreUI.Length; i++)
        {
            scoreUI[i].text = "Score: " + scoreBarrier.score.ToString();
        }
        // for each highscore ui element change its text to display players current score
        for (int i = 0; i < highscoreUI.Length; i++)
        {
            highscoreUI[i].text = "HighScore: " + scoreBarrier.highScore.ToString();
        }
    }

    private void OnEnable()
    {
        PlayerScript.onPlayerDeath += enableGameOverMenu; // toggle ingame and game over ui elements
    }

    private void OnDisable()
    {
        PlayerScript.onPlayerDeath -= enableGameOverMenu; // toggle ingame and game over ui elements
    }

    public void enableGameOverMenu()
    {
        gameOverMenu.SetActive(true); // make game over UI visible
        inGameUI.SetActive(false); // make in game UI visible
    }
}
