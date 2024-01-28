using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Confirm_buy : MonoBehaviour
{
   
    public GameObject LockIcon;
    public GameObject Panel;
    public bool isPurchased = false;
    
    private void Start()
    {
        Button yes = GetComponent<Button>();
        yes.onClick.AddListener(OnClick);

    }

    private void OnClick()
    {
        int highwaycoins = 20;
        int coins = PlayerPrefs.GetInt("CollectedCoins");
        if (!isPurchased)
        {
            coins -= highwaycoins;
            PlayerPrefs.SetInt("CollectedCoins", coins);
            LockIcon.SetActive(false);
            Panel.SetActive(false);
            isPurchased = true;
            PlayerPrefs.SetInt("BoughtLevel", 1);
            Debug.Log("bought hw");


            //save lock icon
            int LockIconActiveValue = LockIcon.activeSelf ? 1 : 0;
            PlayerPrefs.SetInt("LockIconActiveHW", LockIconActiveValue);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Transaction did not go through");
        }

    }
}
