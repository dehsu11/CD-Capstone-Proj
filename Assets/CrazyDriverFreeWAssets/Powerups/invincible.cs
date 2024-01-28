using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessCarChase;

public class invincible : MonoBehaviour
{

    // reference to the player gameobject
    public GameObject player;
    // variable to track if the player is invincible or not
    

    public GameObject invin;

    
    void OnTriggerEnter(Collider other)
    {
        // if the player touches the powerup
        if (other.CompareTag("Player"))
        {
            // make the player invincible
            Invincibiltycontrol script = GameObject.Find("InvinController").GetComponent<Invincibiltycontrol>();
            script.isInvincible = true;

            invin.SetActive(false);



        }
    }

   
}
