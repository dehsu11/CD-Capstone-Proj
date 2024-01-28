using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
namespace CrazyDriver{

public class EndlessCarScipt : MonoBehaviour
{       internal Transform thisTransform;
        static Endlesscontroller gameController;
        GameObject TextScoreEndless;


[Tooltip("The health of the player. If this reaches 0, the player dies")]
        public float health = 10;
        internal float healthMax;
    
        [Tooltip("When the car gets hit and hurt, there is a delay during which it cannot be hit again")]
        public float hurtDelay = 2;
        internal float hurtDelayCount = 0;

        [Tooltip("The color in which the car flashes when hurt")]
        public Color hurtFlashColor = new Color(0.5f, 0.5f, 0.5f, 1);

        [Tooltip("The damage this car causes when hitting other cars. Damage is reduced from Health.")]
        public int damage = 1;
        [Tooltip("The effect that appears when this car is hit by another car")]
        public Transform hitEffect;

        [Tooltip("The effect that appears when this car dies")]
        public Transform deathEffect;

  private void Start()
        {
          thisTransform = this.transform;

            // Set the max health of the car
            healthMax = health;

            // Update the health value
            ChangeHealth(0);
        }

     // Update is called once per frame
        void Update()
        {
        

          
            //if (obstacleDetected > 0) obstacleDetected -= Time.deltaTime;

            // Count down the hurt delay, during which the car can't be hurt again
            if (hurtDelayCount > 0)
            {
                hurtDelayCount -= Time.deltaTime;

                // Change the emission color of the car to indicate that the car is hurt
                if ( GetComponentInChildren<MeshRenderer>() )
                {
                    foreach ( Material part in GetComponentInChildren<MeshRenderer>().materials )
                    {
                        if (Mathf.Round(hurtDelayCount * 10) % 2 == 0) part.SetColor("_EmissionColor", Color.black);
                        else part.SetColor("_EmissionColor", hurtFlashColor);

                        //hurtFlashObject.material.SetColor("_EmissionColor", hurtFlashColor);
                    }
                }

            }




        }

         void OnTriggerEnter(Collider collision)
        {
            if(collision.transform.tag == "Obstacle")
        {

                // Reset the hurt delay
                hurtDelayCount = hurtDelay;
                
                if (health - damage > 0 && hitEffect) Instantiate(hitEffect, transform.position, Quaternion.identity);
                Die();
        }
        }

         public void ChangeHealth(float changeValue)
        {
            // Change the health value
            health += changeValue;

            // Limit the value of the health to the maximum allowed value
            if (health > healthMax) health = healthMax;


            // If this is the player car, play the shake animation

            // If health reaches 0, the car dies
            if (health <= 0)
            {
             
                    // Play a slowmotion effect
                    Time.timeScale = 0.5f;

            }

         //  TextScoreEndless.GetComponent<Text>().text = health.ToString();

          
        }

         public void Die()
        {
            // Create a death effect at the position of the player
            if (deathEffect) Instantiate(deathEffect, transform.position, transform.rotation);

            // Remove the player from the game
            Destroy(gameObject);
        }

        
}
}

