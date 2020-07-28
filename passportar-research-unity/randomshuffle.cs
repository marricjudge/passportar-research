using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class randomshuffle : MonoBehaviour
{
    public int shuffle_result;
    public Toast toast;
    private int guessInput;
    private int ageInput;
    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;
    }

    public void LoadShuffeldScene()
    {
        shuffle_result = Random.Range(0, 2); //Random 0 or 1 (0 is inclusive, 1 is exclusive)
        PlayerPrefs.SetInt("ShuffleResult", shuffle_result);
        PlayerPrefs.Save();
        Debug.Log("Shuffle result is " + shuffle_result);

        int.TryParse(PlayerPrefs.GetString("PreQ3Ans"), out guessInput);
        int.TryParse(PlayerPrefs.GetString("PreQ6Ans"), out ageInput);

        if (PlayerPrefs.GetString("PreQ1Ans") == "Please Select" || PlayerPrefs.GetString("PreQ2Ans") == "Please Select" || PlayerPrefs.GetString("PreQ4Ans") == "Please Select" || PlayerPrefs.GetString("PreQ7Ans") == "Please Select")
        {
            toast.ShowAndroidToastMessage("Please fill all fields");           
        }
        else if (0 > guessInput || guessInput > 201)
        {
            toast.ShowAndroidToastMessage("Number has to be between 0 and 200");
        }
        else if (1900 >= ageInput || ageInput > 2021)
        {
             toast.ShowAndroidToastMessage("Please enter a valid birth year");
        }
        else if (!int.TryParse(PlayerPrefs.GetString("PreQ3Ans"), out guessInput) || !int.TryParse(PlayerPrefs.GetString("PreQ6Ans"), out ageInput))
        {
            toast.ShowAndroidToastMessage("Please enter numbers only");
        } 
        else
        {
            StartNextScene();
        }
    }

    public void StartNextScene()
    {
        PlayerPrefs.SetFloat("SurveyTotalTime", timer);
        PlayerPrefs.Save();

        if (shuffle_result == 0)  //0 is nonAR, 1 is AR
        {
            SceneManager.LoadScene("nonAR");
        }
        else
        {
            SceneManager.LoadScene("AugmentedImage");
        }
    }
}
