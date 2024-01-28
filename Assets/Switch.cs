using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Switch : MonoBehaviour
{

    public AudioMixer audioMixer;
    public string groupName = "MusicSlider";
    public Image On;
    public Image Off;
    private const string PREF_NAME = "toggle_state";
    private bool state = true;

    private void Start()
    {
        if (On == null || Off == null)
        {
            Debug.LogError("On or Off Image not set");
            return;
        }
        state = (PlayerPrefs.GetInt(PREF_NAME, 1) == 1);
        UpdateImages();
    }

    void Update()
    {
        float volume = 0;
        audioMixer.GetFloat(groupName, out volume);
        state = volume > -80;
        UpdateImages();
    }
    public void Toggle()
    {

        state = !state;
        UpdateImages();
        if (state)
            audioMixer.SetFloat(groupName, 0);
        else
            audioMixer.SetFloat(groupName, -80);
    }
    private void UpdateImages()
    {
        On.gameObject.SetActive(state);
        Off.gameObject.SetActive(!state);
    }
}
