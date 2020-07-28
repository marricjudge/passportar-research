using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SendToDatabase : MonoBehaviour
{
    public Toast toast;
    public string uniqueUserID, ARtotaltime, uniqueUserIDvalue;
    private string Name, Nationality, ShuffleResult, SurveyTotalTime;
    private string ARTotalTimeValue, ARTrackingTimeVal, ARCountriesClickedAmount, ARCountriesClickedArray;
    private string NonarSceneTime, NonarCountriesClickedAmount, NonarCountriesClickedArray;
    private string Q1Answer, Q2Answer, Q3, Q4, Q5;
    private string PreQ1Ans, PreQ2Ans, PreQ3Ans, PreQ4Ans, PreQ5Ans, PreQ6Ans, PreQ7Ans;
    public Text Q5text;
    private float timer = 0.0f;
    private float totaltime;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScgpE6knmXu9SeFxOD_xga_fEOsql4swvnI1mOEcz5qiPdMfw/formResponse";

    //Sending to Google Forms concept from https://github.com/luzan/Unity-Google-Spreadsheet 
    IEnumerator Post(string name, string preQ1Ans, string preQ2Ans, string preQ3Ans, string preQ4Ans, string preQ5Ans, string preQ6Ans, string preQ7Ans,
                     string nationality, string shuffleresult, string arTotalTimeVal, string arTrackingTimeVal, string arCountriesClickedAmount, string arCountriesClickedArray, 
                     string nonarSceneTime, string nonarCountriesClickedAmount, string nonarCountriesClickedArray,
                     string q1answer, string q2answer, string q3, string q4, string q5, string surveytotaltime)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.2101691800", name);

        form.AddField("entry.2101700897", preQ1Ans); //Pre Experience Questions
        form.AddField("entry.632447540", preQ2Ans);
        form.AddField("entry.190910270", preQ3Ans);
        form.AddField("entry.72176534", preQ4Ans);
        form.AddField("entry.233028761", preQ5Ans);
        form.AddField("entry.491177590", preQ6Ans);
        form.AddField("entry.607524703", preQ7Ans);

        form.AddField("entry.2107250183", nationality); //AR Variables
        form.AddField("entry.760454961", shuffleresult);
        form.AddField("entry.171165748", arTotalTimeVal);
        form.AddField("entry.1934437059", arTrackingTimeVal);
        form.AddField("entry.1566574269", arCountriesClickedAmount); 
        form.AddField("entry.747507902", arCountriesClickedArray);

        form.AddField("entry.610803084", nonarSceneTime); //Non-AR Scene Time
        form.AddField("entry.730867631", nonarCountriesClickedAmount);  // Non-AR Countries Clicked Amount 
        form.AddField("entry.2113509535", nonarCountriesClickedArray); //Non-AR Countries Clicked Array                         

        form.AddField("entry.1602449622", q1answer); //Post-Experience Questions
        form.AddField("entry.1418519452", q2answer);
        form.AddField("entry.1106010656", q3);
        form.AddField("entry.750657451", q4);
        form.AddField("entry.585844319", q5);

        form.AddField("entry.49387337", surveytotaltime);

        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            toast.ShowAndroidToastMessage("Error. Please try again!");
            Debug.Log(www.error);
        }
        else
        {
            toast.ShowAndroidToastMessage("Sending complete. Thank you");
            Debug.Log("Form upload complete!");

            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("thankyou");
        }
    }

    public void Start()
    {
        totaltime = PlayerPrefs.GetFloat("SurveyTotalTime");

        if (PlayerPrefs.GetString("uniqueUserID") == "" || !PlayerPrefs.HasKey("uniqueUserID"))
        {
            uniqueUserIDvalue = "user" + Random.Range(0, 1000000) + Random.Range(0, 1000000);
            Debug.Log("User ID created " + uniqueUserIDvalue);
            Name = uniqueUserIDvalue;
            PlayerPrefs.SetString("uniqueUserID", uniqueUserIDvalue);
            PlayerPrefs.Save();
        }
        else
        {
            Name = PlayerPrefs.GetString("uniqueUserID");
        }

    }

    public void Update()
    {
        timer += Time.deltaTime;
    }

    public void Send()
    {
        Nationality = PlayerPrefs.GetString("savedNationality");
        ARTotalTimeValue = PlayerPrefs.GetFloat("ARtotaltime").ToString();
        ARTrackingTimeVal = PlayerPrefs.GetFloat("ARTrackingTime").ToString();
        ARCountriesClickedAmount = PlayerPrefs.GetInt("ARtouchedCountrAmount").ToString();
        ARCountriesClickedArray = PlayerPrefs.GetString("ARtouchedCountries");
        ShuffleResult = PlayerPrefs.GetInt("ShuffleResult").ToString();

        PreQ1Ans = PlayerPrefs.GetString("PreQ1Ans");
        PreQ2Ans = PlayerPrefs.GetString("PreQ2Ans");
        PreQ3Ans = PlayerPrefs.GetString("PreQ3Ans");
        PreQ4Ans = PlayerPrefs.GetString("PreQ4Ans");
        PreQ5Ans = PlayerPrefs.GetString("PreQ5Ans");
        PreQ6Ans = PlayerPrefs.GetString("PreQ6Ans");
        PreQ7Ans = PlayerPrefs.GetString("PreQ7Ans");

        NonarSceneTime = PlayerPrefs.GetFloat("nonARSceneTime").ToString(); 
        NonarCountriesClickedAmount = PlayerPrefs.GetInt("nonARtouchedCountrAmount").ToString(); 
        NonarCountriesClickedArray = PlayerPrefs.GetString("nonARtouchedCountries");

        Q1Answer = PlayerPrefs.GetString("Q1Answer");
        Q2Answer = PlayerPrefs.GetString("Q2Answer");
        Q3 = PlayerPrefs.GetString("Q3Answer");
        Q4 = PlayerPrefs.GetString("Q4Answer");
        Q5 = Q5text.text;

        totaltime = PlayerPrefs.GetFloat("SurveyTotalTime");
        totaltime = totaltime + timer;
        SurveyTotalTime = totaltime.ToString();

        if (PlayerPrefs.GetString("Q1Answer") == "Please Select" || PlayerPrefs.GetString("Q2Answer") == "Please Select" || PlayerPrefs.GetString("Q3Answer") == "Please Select" || PlayerPrefs.GetString("Q4Answer") == "Please Select")
        {
            toast.ShowAndroidToastMessage("Please fill all fields");
        } else
        {
            StartCoroutine(Post(Name, PreQ1Ans, PreQ2Ans, PreQ3Ans, PreQ4Ans, PreQ5Ans, PreQ6Ans, PreQ7Ans,
                    Nationality, ShuffleResult, ARTotalTimeValue, ARTrackingTimeVal, ARCountriesClickedAmount, ARCountriesClickedArray,
                    NonarSceneTime, NonarCountriesClickedAmount, NonarCountriesClickedArray,
                    Q1Answer, Q2Answer, Q3, Q4, Q5, SurveyTotalTime));

            Debug.Log("Sending...");
            toast.ShowAndroidToastMessage("Sending...");
        }
    }
}
