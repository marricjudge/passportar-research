using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataTrackerAR : MonoBehaviour
{
    private float timer = 0.0f; //Keeping time reference https://docs.unity3d.com/ScriptReference/Time-deltaTime.html (24.06.2020)
    private float totaltime;
    private int ShuffleResult;

    public GameObject WelcomePanelNonAR, TopPanelNonAR, BottomPanelNonAR;
    public GameObject WelcomePanelAR, TopPanelAR, BottomPanelAR, ScanInfoAR;
    private float IsTracking = 0;

    private void Start()
    {
        totaltime = PlayerPrefs.GetFloat("SurveyTotalTime");
        TopPanelNonAR.SetActive(false);
        BottomPanelNonAR.SetActive(false);
        TopPanelAR.SetActive(false);
        BottomPanelAR.SetActive(false);
        ScanInfoAR.SetActive(false);
        PlayerPrefs.SetInt("NonARPanelClosed", 0);
    }

    void Update()
    {
        timer += Time.deltaTime;

        IsTracking = PlayerPrefs.GetFloat("ARTrackingTime");

        if (IsTracking != 0)
        {
            ScanInfoAR.SetActive(false);
            BottomPanelAR.SetActive(true);
        }
    }

    public void ChangeSceneAfterAR()
    {
        PlayerPrefs.SetFloat("ARtotaltime", timer);
        totaltime += timer;
        PlayerPrefs.SetFloat("SurveyTotalTime", totaltime);
        PlayerPrefs.Save();
        Debug.Log("AR total time at save is " + timer);

        ShuffleResult = PlayerPrefs.GetInt("ShuffleResult");

        if (ShuffleResult == 0) //NonAR first, then AR and then load the post questionnaire
        {
          SceneManager.LoadScene("post-questionnaire");
        } else if (ShuffleResult == 1)
        {
            SceneManager.LoadScene("nonAR");
        }
    }

    public void ChangeSceneAfterNonAR()
    {
        PlayerPrefs.SetFloat("nonARSceneTime", timer);
        totaltime += timer;
        PlayerPrefs.SetFloat("SurveyTotalTime", totaltime);
        PlayerPrefs.Save();
        Debug.Log("NonAR Scene time at save is " + timer);

        ShuffleResult = PlayerPrefs.GetInt("ShuffleResult");

        if (ShuffleResult == 1) //NonAR first, then AR and then load the post questionnaire
        {
            SceneManager.LoadScene("post-questionnaire");
        }
        else if (ShuffleResult == 0)
        {
            SceneManager.LoadScene("AugmentedImage");
        }
    }

    public void HideWelcomeMessageNonAR()
    {
        WelcomePanelNonAR.SetActive(false);
        TopPanelNonAR.SetActive(true);
        BottomPanelNonAR.SetActive(true);
        PlayerPrefs.SetInt("NonARPanelClosed", 1);
    }

    public void HideWelcomeMessageAR()
    {
        WelcomePanelAR.SetActive(false);
        TopPanelAR.SetActive(true);       
        ScanInfoAR.SetActive(true);
    }
}
