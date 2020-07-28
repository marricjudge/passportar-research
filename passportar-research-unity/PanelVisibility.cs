using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class PanelVisibility : MonoBehaviour
{
    public GameObject PanelBottom;

    void Start()
    {
        PanelBottom.SetActive(false);     
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("IsTracked") == 1 )
        {
            PanelBottom.SetActive(true);
        }
    }
}
