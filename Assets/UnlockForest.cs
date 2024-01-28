using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockForest : MonoBehaviour
{
    private Confirm_buy check;
    public int requiredCoins;
    public GameObject ConfirmPanel;
    public ConfirmBuyForest Check;

    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

    }

    private void OnClick()
    {

        int currentCoins = PlayerPrefs.GetInt("CollectedCoins", 0);
        if (PlayerPrefs.HasKey("BoughtLevelForest"))
        {
            if (PlayerPrefs.GetInt("BoughtLevelForest") == 1)
            {
                
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
