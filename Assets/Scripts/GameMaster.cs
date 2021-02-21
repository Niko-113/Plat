using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public Text scoreText;
    public Text coinText;
    public Text worldText;
    public Text timeText;

    private int coinCount = 0;
    private DateTime startTime;
    private TimeSpan difference;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;
        difference = (startTime - currentTime);
        timeText.text = ("TIME" + "\n " + (400 + difference.Seconds));
    }

    public void getCoin(){
        coinCount++;
        coinText.text = "x ";
        if (coinCount < 10){
            coinText.text += "0";
        }
        coinText.text += coinCount;
    }
}
