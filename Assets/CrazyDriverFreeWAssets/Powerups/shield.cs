//not working yet
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessCarChase;

public class shield : MonoBehaviour
{
   public float multiplier= 100f;
    public float seconds = 3f;
    void OnTriggerEnter(Collider invicollider)
    {
        if(invicollider.CompareTag("Player"))
        {
            StartCoroutine(Pickup(invicollider));
        }
    }
    IEnumerator Pickup(Collider player)
    {
        Debug.Log("pickedup");

        CrazyCar attributes = player.GetComponent<CrazyCar>();
        attributes.health *=multiplier;
        GetComponent<MeshRenderer>().enabled= false;
        GetComponent<Collider>().enabled =false;
        yield return new WaitForSeconds(seconds);

        attributes.health /= multiplier;

        Destroy(gameObject);
    }
}
