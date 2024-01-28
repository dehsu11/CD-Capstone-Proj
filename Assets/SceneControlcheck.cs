using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneControlcheck : MonoBehaviour
{
    public GameObject level1Border;
    public GameObject level2Border;
    public GameObject level3Border;

    public void LoadScene() { 
    
            if (level1Border.activeSelf)
            {
                
               SceneManager.LoadScene("Scene_Island Highway Race");
            }
        
    if (PlayerPrefs.HasKey("BoughtLevelDesert"))
        {
            if (PlayerPrefs.GetInt("BoughtLevelDesert") == 1 && level2Border.activeSelf)
            {
                
               SceneManager.LoadScene("Desset");
            }
        }
        if (PlayerPrefs.HasKey("BoughtLevelForest"))
        {
            if (PlayerPrefs.GetInt("BoughtLevelForest") == 1 && level3Border.activeSelf)
            {

                SceneManager.LoadScene("forest");
            }
        }

    }
    
}

