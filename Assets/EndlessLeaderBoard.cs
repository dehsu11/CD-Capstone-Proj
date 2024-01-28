using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessLeaderBoard : MonoBehaviour
{
    public Text scoreHighway;
    public Text scoreDesert;
    public Text scoreForest;
    

    // Update is called once per frame
    void Update()
    {
        scoreHighway.text= "Highscore: " +  PlayerPrefs.GetInt("Scene_Island Highway Race"+"HighScore").ToString();
        scoreDesert.text = "Highscore: " + PlayerPrefs.GetInt("Desert" + "HighScore").ToString();
        scoreForest.text = "Highscore: " + PlayerPrefs.GetInt("forest" + "HighScore").ToString();
    }
}
