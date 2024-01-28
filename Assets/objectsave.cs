using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class objectsave : MonoBehaviour
{   
       public GameObject[] objectsToSave; // an array of GameObjects whose active states we want to save

    private bool[] objectsActiveState;

    // Use this for initialization
    void Start()
    {
        objectsActiveState = new bool[objectsToSave.Length];
        // Load the active state of each GameObject from PlayerPrefs
        for(int i = 0; i < objectsToSave.Length; i++)
        {
            bool loadedState = PlayerPrefs.GetInt("ObjectActive"+i, 0) == 1;
            objectsToSave[i].SetActive(loadedState);
            objectsActiveState[i] = loadedState;
        }
    }

    void OnApplicationQuit()
    {
        // Save the active state of each GameObject to PlayerPrefs if it has changed
        for(int i = 0; i < objectsToSave.Length; i++)
        {
            if(objectsActiveState[i] != objectsToSave[i].activeSelf)
            {
                PlayerPrefs.SetInt("ObjectActive"+i, objectsToSave[i].activeSelf ? 1 : 0);
                objectsActiveState[i] = objectsToSave[i].activeSelf;
            }
        }
    }
}
