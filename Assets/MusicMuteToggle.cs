using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicMuteToggle : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string groupName = "MusicSlider";
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
