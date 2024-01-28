using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollected_FW : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
       
            PlayerManager.collectedCoins++;
            PlayerPrefs.SetInt("CollectedCoins", PlayerManager.collectedCoins);
            
        }
    }
}
