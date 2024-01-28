using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessCarChase;

public class speedup : MonoBehaviour
{
    public float multiplier= 1.5f;
    public float seconds = 1f;
    void OnTriggerEnter(Collider speedcollider)
    {
        if(speedcollider.CompareTag("Player"))
        {
            StartCoroutine(Pickup(speedcollider));
        }
    }
    IEnumerator Pickup(Collider player)
    {
        Debug.Log("pickedup speed");

        CrazyCar attributes = player.GetComponent<CrazyCar>();
        attributes.speed *=multiplier;
        GetComponent<MeshRenderer>().enabled= false;
        GetComponent<Collider>().enabled =false;
        yield return new WaitForSeconds(seconds);

        attributes.speed /= multiplier;

        Destroy(gameObject);
    }
}
