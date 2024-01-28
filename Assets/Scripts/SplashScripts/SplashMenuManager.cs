using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class SplashMenuManager : MonoBehaviour
    {


        [Header("Options Panel")]
        public GameObject splashScreen;
        public GameObject stageScreen;
        public GameObject settingsScreen;
        public GameObject aboutUsScreen;
        public GameObject creditsScreen;
        public GameObject storyScreen;
        public GameObject garageUI;
        public GameObject leaderboardScreen;
        public Confirm_buy Highway;
        public ConfirmBuyDesert Desert;
        public ConfirmBuyForest Forest;
        
    void Start() {
        if (PlayerPrefs.HasKey("LockIconActiveHW"))
        {
            bool isActive = PlayerPrefs.GetInt("LockIconActiveHW") == 1;
            Highway.LockIcon.SetActive(isActive);
        }
        if (PlayerPrefs.HasKey("LockIconActiveDS"))
        {
            bool isActive = PlayerPrefs.GetInt("LockIconActiveDS") == 1;
            Desert.LockIcon.SetActive(isActive);
        }
        if (PlayerPrefs.HasKey("LockIconActiveFR"))
        {
            bool isActive = PlayerPrefs.GetInt("LockIconActiveFR") == 1;
            Forest.LockIcon.SetActive(isActive);
        }
    }
    public void openLeaderboard()
        {
           leaderboardScreen.SetActive(true);
                stageScreen.SetActive(false);
                splashScreen.SetActive(false);
                settingsScreen.SetActive(false);
        }
        public void closeLeaderboard()
        {
                stageScreen.SetActive(false);
                splashScreen.SetActive(true);
                settingsScreen.SetActive(false);
        }
         public void openStory()
        {
           storyScreen.SetActive(true);
                stageScreen.SetActive(false);
                splashScreen.SetActive(false);
                settingsScreen.SetActive(false);
        }
        public void closeStory()
        {
                storyScreen.SetActive(false);
                stageScreen.SetActive(false);
                splashScreen.SetActive(true);
                settingsScreen.SetActive(true);
                 garageUI.SetActive(false);
        
                
        }
      public void openStage()
        {
                stageScreen.SetActive(true);
                splashScreen.SetActive(false);
                settingsScreen.SetActive(false);
        }
      public void closeStage()
        {
                stageScreen.SetActive(false);
                splashScreen.SetActive(true);
                settingsScreen.SetActive(false);
        }
      public void openSettings()
        {
                settingsScreen.SetActive(true);
                stageScreen.SetActive(false);
                garageUI.SetActive(false);
               
        }
     public void closeSettings()
        {
                garageUI.SetActive(true);
                settingsScreen.SetActive(false);
                stageScreen.SetActive(false);
                splashScreen.SetActive(true);
               
        }
        public void openAboutUs()
        {
                aboutUsScreen.SetActive(true);
                settingsScreen.SetActive(false);
                stageScreen.SetActive(false);
                garageUI.SetActive(false);
               
        }
     public void closeAboutUs()
        {
                garageUI.SetActive(false);
                aboutUsScreen.SetActive(false);
                settingsScreen.SetActive(true);
                stageScreen.SetActive(false);
                splashScreen.SetActive(true);
               
        } public void openCredits()
        {
                creditsScreen.SetActive(true);
                settingsScreen.SetActive(false);
                stageScreen.SetActive(false);
                garageUI.SetActive(false);
               
        }
     public void closeCredits()
        {
                garageUI.SetActive(false);
                creditsScreen.SetActive(false);
                settingsScreen.SetActive(true);
                stageScreen.SetActive(false);
                splashScreen.SetActive(true);
               
        }
      /**  public void openInformation()
        {
              informationScreen.SetActive(true);
                settingsScreen.SetActive(false);
                levelsScreen.SetActive(false);
                splashScreen.SetActive(false);
               
        }
        public void closeInformation()
        {
           splashScreen.SetActive(true);
              informationScreen.SetActive(false);
                settingsScreen.SetActive(false);
                levelsScreen.SetActive(false);
                
               
        }
        **/



    }
