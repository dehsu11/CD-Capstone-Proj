using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHover : MonoBehaviour
{ // Reference to the border image
    public Image borderImage;

    // Color for the border when clicked
    public Color clickedColor;

    // Color for the border when not clicked
    public Color normalColor;

    // Level number
    public int levelNumber;

    // Current selected level
    public Image selectedLevel;

    void Start()
    {
        // Set the initial border color to the normal color
        borderImage.color = normalColor;
    }

    public void OnClick()
    {
        Debug.Log("Clicked");
        // Set the selected level
        selectedLevel = borderImage;

        // Change the border color to the clicked color
        borderImage.color = clickedColor;
        
    }

    public void OnPointerUp()
    {
        // Change the border color back to the normal color
        borderImage.color = normalColor;
    }
}
