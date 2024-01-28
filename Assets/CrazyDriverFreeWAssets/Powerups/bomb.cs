using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace EndlessCarChase
{
public class bomb : MonoBehaviour
{
    static CrazyGameController gameController;
    public Transform deathEffect;

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Get all enemy gameobjects in the scene
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            gameController = GameObject.FindObjectOfType<CrazyGameController>();

            // Destroy each enemy gameobject
            foreach (GameObject enemy in enemies)
            {
                Debug.Log("Pickedup bomb");
                Destroy(enemy);
                Destroy(gameObject);
                if (deathEffect) Instantiate(deathEffect, enemy.transform.position, transform.rotation);
                gameController.score +=1;
            }
        }
    }


    
    

  
}
}
