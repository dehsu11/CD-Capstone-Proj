using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioSwitch : MonoBehaviour
{
    public Image On;
    public Image Off;
    private const string PREF_NAME = "toggle_state_Sound";
    private bool state = true;

    private void Start()
    {
        if (On == null || Off == null)
        {
            Debug.LogError("On or Off Image not set");
            return;
        }
        state = (PlayerPrefs.GetInt(PREF_NAME, 1) == 1);
        SetImages();
    }

    public void Toggle()
    {
        state = !state;
        SetImages();
        PlayerPrefs.SetInt(PREF_NAME, state ? 1 : 0);
    }

    private void SetImages()
    {
        On.gameObject.SetActive(state);
        Off.gameObject.SetActive(!state);
    }
}
