using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StroyPrefs : MonoBehaviour
{
    public GameObject StoryPanel;
    public GameObject garage;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("StoryShown"))
        {
            if (PlayerPrefs.GetInt("StoryShown") == 1)
            {
                StoryPanel.SetActive(false);
                garage.SetActive(true);

            }
        }    
    }

    
    public void StoryShown()
    {
        PlayerPrefs.SetInt("StoryShown", 1);
    }
}
