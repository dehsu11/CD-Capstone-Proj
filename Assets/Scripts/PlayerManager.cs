using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static int collectedCoins;
    public Text coinsText;

    void Update()
    {
        coinsText.text = collectedCoins.ToString();
        coinsText.text = collectedCoins.ToString();
        Awake();
    }

    private void Awake()
    {
        collectedCoins = PlayerPrefs.GetInt("CollectedCoins", 0);
    }
}
