using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public AudioSource collectSound;
    public Transform playerTransform;
    public float moveSpeed = 30f;

    

    

    public void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Car").transform;
                
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "Car")
        {
            collectSound.Play();
            PlayerManager.collectedCoins++;
            PlayerPrefs.SetInt("CollectedCoins", PlayerManager.collectedCoins);
            Destroy(gameObject);
        }
        
        
    }
    
}
