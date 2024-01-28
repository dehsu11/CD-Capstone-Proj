using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibiltycontrol : MonoBehaviour
{
    public bool isInvincible = false;
    public float invincibilityTime = 10.0f;
    public GameObject player;
    // Start is called before the first frame update
    void Update()
    {
        Invincibility();
    }

    // Update is called once per frame
    public void Invincibility()
    {
        if (isInvincible)

        {
            
            // disable collision with enemies to prevent them from damaging the player
            Physics.IgnoreLayerCollision(player.layer, LayerMask.NameToLayer("Enemies"), true);

            // decrease the invincibility time
            invincibilityTime -= Time.deltaTime;


        }
        if (invincibilityTime <= 0)
        {
            // make the player no longer invincible 

            isInvincible = false;
           
            // enable collision with enemies
            Physics.IgnoreLayerCollision(player.layer, LayerMask.NameToLayer("Enemies"), false);
            
        }
    }
}

