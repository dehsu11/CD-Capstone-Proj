using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelBuy : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        Button no = GetComponent<Button>();
        no.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        
      
            Panel.SetActive(false);
           


    }
}
