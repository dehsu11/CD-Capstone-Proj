using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SfxMuteToggle : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string groupName = "Master";
    public Button muteButton;
    public Button unmuteButton;

    private void Start()
    {
        muteButton.onClick.AddListener(Mute);
        unmuteButton.onClick.AddListener(Unmute);
    }

    public void Mute()
    {
        audioMixer.SetFloat(groupName, -80);
    }

    public void Unmute()
    {
        audioMixer.SetFloat(groupName, 0);
    }
}

