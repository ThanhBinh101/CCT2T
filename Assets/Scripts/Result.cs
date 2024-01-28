using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject up1;
    public GameObject up2;
    public GameObject down1;
    public GameObject down2;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show(string name) {
        gameObject.SetActive(true);
        if(name == "Character")
        {
            up1.SetActive(true);
            up2.SetActive(false);
            down1.SetActive(false);
            down2.SetActive(true);
        }
        else
        {
            up1.SetActive(false);
            up2.SetActive(true);
            down1.SetActive(true);
            down2.SetActive(false);
        }
    }
}
