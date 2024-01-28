using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCamera : MonoBehaviour
{
 	public GameObject Player;
    public GameObject cameralookAt,cameraPos;
    public float speed = 0;

    [Range (0, 50)] public float smothTime = 8;

    private void Start () {
       Player = GameObject.FindGameObjectWithTag ("Player");

          cameralookAt = Player.transform.Find ("camera lookAt").gameObject;
        cameraPos = Player.transform.Find ("camera constraint").gameObject;
      

        
    }

    

    private void FixedUpdate () {
        follow ();

    }
    private void follow () {
        gameObject.transform.position = Vector3.Lerp (transform.position, cameraPos.transform.position ,  Time.deltaTime * speed);
        gameObject.transform.LookAt (cameralookAt.gameObject.transform.position);
    }

}
