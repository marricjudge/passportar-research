using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastHelpAR : MonoBehaviour
{
    public Toast toast;
    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (PlayerPrefs.GetInt("IsTracked") == 0) //While not tracking
        {
            if (timer == 10.0f)
            {
               // toast.ShowAndroidToastMessage("Hold your passport   ");
            } else if (timer > 20.0f)
            {
               // toast.ShowAndroidToastMessage("over 20 secs");
            }

        }
    }
}
