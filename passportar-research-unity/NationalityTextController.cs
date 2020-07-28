using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;

public class NationalityTextController : MonoBehaviour
{
    public Text NationalityText;
    private PassportIdentDict passportIdentDictContr;
    private string currentNationality; //might be outdated
    public string receivedNationality;
    private int currentNationalityInt;
    private string savedNationality;

    public void Awake()
    {
        passportIdentDictContr = GameObject.FindObjectOfType<PassportIdentDict>();
    }

    private void Start()
    {
        PlayerPrefs.SetString("savedNationality", " ");
        PlayerPrefs.Save();
    }

    public void catchNationality(string nationality) //from https://www.youtube.com/watch?v=ck6OyNBC95c 08-05-2020
    { //This function might be outdated 
        currentNationality = nationality;
    }

    public void catchNationalityInt(int nationalityInt) //Gets the recognised passport int from AugmendImageVisualizer.cs
    {
        currentNationalityInt = nationalityInt;
    }    

    void Update()
    {
        receivedNationality = passportIdentDictContr.catchPassportIntToString(currentNationalityInt); //look up in dictionary
        //NationalityText.text = receivedNationality; //Sets received nationality to text UI element
        Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
        //NationalityText.transform.position = namePose; //Show text on lower left corner of the tracked passport
        PlayerPrefs.SetString("savedNationality", receivedNationality);
        PlayerPrefs.Save();
    }
}
