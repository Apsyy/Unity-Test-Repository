using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        PlayerScript.onPlayerDeath += enableGameOverMenu; // call enable game over menu on death
    }

    private void OnDisable()
    {
        PlayerScript.onPlayerDeath -= enableGameOverMenu; // disable game over menu on level start
    }

    public void enableGameOverMenu()
    {
        gameOverMenu.SetActive(true); // make game over UI visible
    }
}
