using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyDriver;
public class ScoreMultiplier : MonoBehaviour
{
    public int multiplier = 2; // The multiplier value
    public float duration = 5f; // The duration of the powerup
    private bool isPowerupActive = false;
    private int defaultMultiplier = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            Debug.Log("picked");
           
            StartCoroutine(ActivateMultiplier());

            
            Destroy(gameObject);
        }
    }

    private IEnumerator ActivateMultiplier()
    {
        // Find the GameObject with the Score component
        GameObject scoreObject = GameObject.FindWithTag("GameController");

        if (scoreObject == null)
        {
            
            Debug.Log("No GameController Found");
            yield break;
        }

       
        Endlesscontroller score = scoreObject.GetComponent<Endlesscontroller>();
        int originalScore = score.scorePerSecond;

      
        score.scorePerSecond = multiplier;

        isPowerupActive = true;

       
        yield return new WaitForSeconds(duration);

        
        score.scorePerSecond = defaultMultiplier;
        isPowerupActive = false;
    }

}
