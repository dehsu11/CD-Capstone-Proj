using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum alphaValue
{
    FadeOut,
    FadeIn
}

public class Blink : MonoBehaviour
{
    public alphaValue currentAlphaValue;
    public float CommentMinAlpha;
    public float CommentMaxAlpha;
    public float CommentCurrentAlpha;
    [SerializeField] TextMeshProUGUI myText;

    // Start is called before the first frame update
    void Start()
    {
        CommentMinAlpha = 0.2f;
        CommentMaxAlpha = 3f;
        CommentCurrentAlpha = 3f;
        currentAlphaValue = alphaValue.FadeOut;
    }

    // Update is called once per frame
    void Update()
    {
        AlphaComments(); 
    }
    public void AlphaComments()
    {
        if(currentAlphaValue== alphaValue.FadeOut)
        {
            CommentCurrentAlpha = CommentCurrentAlpha - 0.01f;
            myText.color = new Color(Color.black.r, Color.black.g, Color.black.b, CommentCurrentAlpha);
            if(CommentCurrentAlpha <= CommentMinAlpha)
            {
                currentAlphaValue = alphaValue.FadeIn;
            }
        }
        else if (currentAlphaValue == alphaValue.FadeIn)
        {
            CommentCurrentAlpha = CommentCurrentAlpha + 0.01f;
            myText.color = new Color(Color.black.r, Color.black.g, Color.black.b, CommentCurrentAlpha);
            if(CommentCurrentAlpha >= CommentMaxAlpha)
            {
                currentAlphaValue = alphaValue.FadeOut;
            }
        }
    }

}
