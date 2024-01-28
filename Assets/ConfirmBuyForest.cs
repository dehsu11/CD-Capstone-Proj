using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmBuyForest : MonoBehaviour
{
    public GameObject LockIcon;
    public GameObject Panel;
    public bool isPurchased = false;
    private void Start()
    {
        Button yesforest = GetComponent<Button>();
        yesforest.onClick.AddListener(OnClick);

     
    }

    private void OnClick()
    {
        int forestcoins = 1000;
        int coins = PlayerPrefs.GetInt("CollectedCoins");
        if (!isPurchased)
        {
            coins -= forestcoins;
            PlayerPrefs.SetInt("CollectedCoins", coins);
            LockIcon.SetActive(false);
            Panel.SetActive(false);
            isPurchased = true;
            PlayerPrefs.SetInt("BoughtLevelForest", 1);
            Debug.Log("forest bought");

            //save lock icon
            int LockIconActiveValue = LockIcon.activeSelf ? 1 : 0;
            PlayerPrefs.SetInt("LockIconActiveFR", LockIconActiveValue);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Transaction did not go through");
        }

    }
}
