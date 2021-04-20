using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Tooltip("Coins")]
    public TMP_Text coinsText;
    public int coins;

    [Tooltip("Time")]
    public TMP_Text currentTime;

    [Tooltip("Time Slowdown")]
    public int slowdown;

    double hours = 0;
    public int gameTime = 0;



    private void Update()
    {
        coinsText.text = "Coins: " + coins;

        hours = hours + Time.deltaTime/slowdown;

        if (hours > 24) 
        {
            hours = 0;
        }

        gameTime = (int)hours;
        currentTime.text = "Time: " + gameTime;       








    }

}
