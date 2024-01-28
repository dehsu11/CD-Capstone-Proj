using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmBuyDesert : MonoBehaviour
{
    public GameObject LockIcon;
    public GameObject Panel;
    public bool isPurchased = false;
    private void Start()
    {
        Button yesdesert = GetComponent<Button>();
        yesdesert.onClick.AddListener(OnClick);

    }

    private void OnClick()
    {
        int desertcoins = 500;
        int coins = PlayerPrefs.GetInt("CollectedCoins");
        if (!isPurchased)
        {
            coins -= desertcoins;
            PlayerPrefs.SetInt("CollectedCoins", coins);
            LockIcon.SetActive(false);
            Panel.SetActive(false);
            isPurchased = true;
            PlayerPrefs.SetInt("BoughtLevelDesert", 1);
            Debug.Log("desertbought");

            //save lock icon
            int LockIconActiveValue = LockIcon.activeSelf ? 1 : 0;
            PlayerPrefs.SetInt("LockIconActiveDS", LockIconActiveValue);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Transaction did not go through");
        }

    }
}
