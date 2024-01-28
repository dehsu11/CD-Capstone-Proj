using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    Animator anim;

    public string newGameSceneName;
    public int quickSaveSlotID;

    public string ButtonClickSFX;

    [Header("Options Panel")]
    public GameObject MainOptionsPanel;
    public GameObject StartGameOptionsPanel;
   


    private void Awake()
    {
       
    
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

        //new key
    #if !EMM_ES2
        PlayerPrefs.SetInt("quickSaveSlot", quickSaveSlotID);
    #else
        ES2.Save(quickSaveSlotID, "quickSaveSlot");
    #endif
    }

    #region Open Different panels

   
    public void openStartGameOptions()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(false);
        StartGameOptionsPanel.SetActive(true);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
 
        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");
        
    }
  public void Quit()
    {
        Application.Quit();
    }
   


    }

   

   

  

  
#endregion




