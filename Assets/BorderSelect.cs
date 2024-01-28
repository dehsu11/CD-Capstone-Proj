using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BorderSelect : MonoBehaviour
{
    public Image level1Border;
    public Image level2Border;
    public Image level3Border;
    public void SelectLevel1()
    {
        level1Border.gameObject.SetActive(true);
        level2Border.gameObject.SetActive(false);
        level3Border.gameObject.SetActive(false);
    }

    public void SelectLevel2()
    {
        level1Border.gameObject.SetActive(false);
        level2Border.gameObject.SetActive(true);
        level3Border.gameObject.SetActive(false);
    }
     public void SelectLevel3()
    {
        level1Border.gameObject.SetActive(false);
        level2Border.gameObject.SetActive(false);
        level3Border.gameObject.SetActive(true);
    }

}
