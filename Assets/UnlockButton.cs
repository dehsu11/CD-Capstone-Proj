using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnlockButton : MonoBehaviour
{
    private Confirm_buy check;
    public int requiredCoins;
    public GameObject ConfirmPanel;
    public Confirm_buy Check;

    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

    }

    private void OnClick()
    {
        
        int currentCoins = PlayerPrefs.GetInt("CollectedCoins", 0);
        if (PlayerPrefs.HasKey("BoughtLevel"))
        {
            if (PlayerPrefs.GetInt("BoughtLevel") == 1)
            {
                // Exit the function if the popups have been shown before
                return;
            }
        }


        else if (Check.isPurchased == false && currentCoins >= requiredCoins)
        {

            ConfirmPanel.SetActive(true);
        }
        else
        {
            // Not enough coins, do something else
            Debug.Log("Not enough coins");
        }
            
        
    }
}

