using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CrazyDriver;


public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float sidewardsSpeed = 3;
    float targetPositionX;
    public int desiredLane = 0;
    public float laneDistance = 2.5f;
    float test = 0.04f;
    //time when will the speed increase
    float timer = 0;
    public float maxSpeed;
    public GameObject trigger;
    



    public bool CanMoveLeft => desiredLane > 0;
    public bool CanMoveRight => desiredLane < 3;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        targetPositionX = transform.position.x;
        
    }
    
    void Update()
    {
        Endlesscontroller script = GameObject.Find("Game").GetComponent<Endlesscontroller>();
        if (!script.gameStarted)
        {
            return;
        }
        if (Time.timeScale == 0) return; // Don't update if game is paused

        // Finally calculate a smoothed movement on the individual axes
        var currentPosition = transform.position;
        var deltaX = targetPositionX - currentPosition.x;
        
        var x = Mathf.Sign(deltaX) * Mathf.Min(Mathf.Abs(deltaX), sidewardsSpeed * Time.fixedDeltaTime);
        var y = 0;
        var z = forwardSpeed * Time.fixedDeltaTime;
        transform.position += new Vector3(0, 0, z);
        timer += Time.fixedDeltaTime;
        if (timer >= 180)
        {
            forwardSpeed += 1;
            timer = 0;
            if (forwardSpeed >= maxSpeed)
            {
                forwardSpeed = maxSpeed;
            }
        }
        controller.Move(new Vector3(x, y, z));



    }



    public void MoveLane(bool goingRight)
    {
        var direction = goingRight ? 1 : -1;
        desiredLane += direction;
        desiredLane = Mathf.Clamp(desiredLane, 0, 3);



        // Also directly calculate the target X position     
        targetPositionX = (desiredLane - 2) * laneDistance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpawnTrigger")
        {
            Destroy(trigger.gameObject);
        }
    }

}
