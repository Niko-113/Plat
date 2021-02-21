using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public Text scoreText;
    public Text coinText;
    public Text worldText;
    public Text timeText;

    private int coinCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE\n00000";
    }

    // Update is called once per frame
    void Update()
    {
        
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
