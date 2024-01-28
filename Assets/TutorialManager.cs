using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessCarChase;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] TextPopups;
    private int PopUpIndex;
    bool waitTime;

    public CrazyGameController buttonScript;

    IEnumerator WaitForPopup()
    {
        waitTime = true;
        yield return new WaitForSeconds(5f); // wait for 5 seconds
        PopUpIndex++;
        waitTime = false;
    }

    void Update()
    {
        if (buttonScript.gameStarted)
        {
            // Check if the popups have been shown before
            if (PlayerPrefs.HasKey("PopupsShown"))
            {
                if (PlayerPrefs.GetInt("PopupsShown") == 1)
                {
                    // Exit the function if the popups have been shown before
                    return;
                }
            }
            for (int i = 0; i < TextPopups.Length; i++)
            {
                if (i == PopUpIndex)
                {
                    TextPopups[i].SetActive(true);
                }
                else
                {
                    TextPopups[i].SetActive(false);
                }
            }
            if (PopUpIndex == 0)
            {
                if (Application.isMobilePlatform)
                {
                    if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);
                        if (touch.phase == TouchPhase.Began)
                        {
                            float touchX = Mathf.Clamp01(touch.position.x / Screen.width);
                            if (touchX >= 0.5f && !waitTime)
                            {
                                StartCoroutine(WaitForPopup());
                            }
                        }
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.D) && !waitTime)
                    {
                        StartCoroutine(WaitForPopup());
                    }
                }
            }


            else if (PopUpIndex == 1)
            {
                if (Application.isMobilePlatform)
                {
                    if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);
                        if (touch.phase == TouchPhase.Began)
                        {
                            float touchX = Mathf.Clamp01(touch.position.x / Screen.width);
                            if (touchX <= 0.5f && !waitTime)
                            {
                                StartCoroutine(WaitForPopup());
                            }
                        }
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.A) && !waitTime)
                    {
                        StartCoroutine(WaitForPopup());
                    }
                }
            }
            else if (PopUpIndex == 2 || PopUpIndex == 3)
            {
                if (!waitTime)
                {
                    StartCoroutine(WaitForPopup());
                }
            }



            // Check if all the popups have been displayed
            if (PopUpIndex == TextPopups.Length)
            {
                // Hide all the text popups
                for (int i = 0; i < TextPopups.Length; i++)
                {
                    TextPopups[i].SetActive(false);
                }
                // When the popups are done dont show again
                PlayerPrefs.SetInt("PopupsShown", 1);
            }
        }
    }
}
