using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject inGameUI;

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
