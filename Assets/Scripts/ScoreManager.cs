using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI[] distanceUI;
    public float rateOfDistance;
    private float distance;

    

    private void Update()
    {
        // for each distance ui element change its text to display the distance travelled
        for (int i = 0; i < distanceUI.Length; i++)
        {
            distanceUI[i].text = "Distance: " + distance.ToString("F0");
        }
        // update distance (add multiplier for when objects/player moves faster)
        distance += Time.deltaTime * rateOfDistance;
    }
}
