using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FreeworldLeaderboard : MonoBehaviour
{
    public Text scoreEndless;


    // Update is called once per frame
    void Update()
    {
        scoreEndless.text = "Highscore: " + PlayerPrefs.GetInt("CrazyDriverFreeWorld" + "HighScore_FW").ToString();
    }
}
