using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    public GameObject message;//Reference of the message window
    public GameObject menu;//Reference of the menu window

    private bool showStartMessage=true;
    private string showStartMessageDataName = "PopupsShown";

    void Start()
    {
        showStartMessage = PlayerPrefs.GetInt(showStartMessageDataName,1)==1;//Read integer from memory and convert it into a boolean variable

        message.SetActive(showStartMessage);//initialize windows
        menu.SetActive(showStartMessage);
    }

    public void ShowMessageAgainToggle(bool b)
    {
        showStartMessage = !b; //Check means don't show it anymore
    }

    public void StartMessageOkButton()
    {
        if (!showStartMessage)
        {
            PlayerPrefs.SetInt(showStartMessageDataName,0);//write bool in memory as an integer
        }
        message.SetActive(false);
        menu.SetActive(true);
    }

    public void RestoreDefaultConfiguration()
    {
        //PlayerPrefs.DeleteAll(); //Dangerous

        PlayerPrefs.DeleteKey(showStartMessageDataName);//Delete specific data
    }

}
