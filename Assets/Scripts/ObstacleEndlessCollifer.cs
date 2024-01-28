using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEndlessCollifer : MonoBehaviour
{
      public AudioSource collectSound;
     void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "Player")
        {
            collectSound.Play();
            PlayerManager.collectedCoins++;
            PlayerPrefs.SetInt("CollectedCoins", PlayerManager.collectedCoins);
            Destroy(gameObject);
        }
    }
}
