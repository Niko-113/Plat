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
    public Text overText;

    public static GameMaster master;

    private int coinCount = 0;
    private int score = 0;
    public int time = 0;
    private DateTime startTime;
    private TimeSpan difference;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.Now;
        master = this.GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;
        difference = (startTime - currentTime);
        // if (difference.Seconds == -59){
        //     time = -60;
        // }
        time = (int) difference.TotalSeconds ;
        timeText.text = ("TIME" + "\n " + (100 + time));
        if(100 + time < 0){
            GameOver();
        }
    }

    public void getCoin(){
        coinCount++;
        coinText.text = "x ";
        if (coinCount < 10){
            coinText.text += "0";
        }
        coinText.text += coinCount;
    }

    public void addPoints(){
        score += 100;
        scoreText.text = ("SCORE" + "\n " + score.ToString("D5"));
    }

    public void GameOver(){
        Rigidbody rb = player.GetComponent<Rigidbody>();

        rb.constraints = new RigidbodyConstraints();
        rb.AddForce(rb.transform.right, ForceMode.VelocityChange);

        overText.text = "GAME OVER";
    }

    public void Victory(){
        overText.text = ("CONGRATULATION ! ! !");
        overText.color = (Color.green);
    }
}
