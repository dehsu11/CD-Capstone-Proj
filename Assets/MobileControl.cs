using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobileControl : MonoBehaviour
{
    public PlayerController script;

    public Button left;
    public Button right;

    public void Start()
    {
        GameObject[] playerControllerObjects = GameObject.FindGameObjectsWithTag("Car");

        foreach (GameObject playerControllerObject in playerControllerObjects)
        {
            script = playerControllerObject.GetComponent<PlayerController>();
        }

        left.onClick.AddListener(OnLeftbutton);
        right.onClick.AddListener(OnRightbutton);
    }
    // Update is called once per frame
    

    public void OnLeftbutton()
    {
        if(script.CanMoveLeft)
        {
            
            script.MoveLane(false);
            Debug.Log("left");
        }
        
    }
    public void OnRightbutton()
    {
        if (script.CanMoveRight)
        {
            script.MoveLane(true);
            Debug.Log("Right");
        }
    }
 
}
