using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateUserID : MonoBehaviour
{ //UserID now generated in SendToDatabase. This script checks if a ID exists, saves it, delete all other user data and reassignes the old id
    public string previousUserID;

    void Start()
    {
        previousUserID = PlayerPrefs.GetString("uniqueUserID");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("uniqueUserID", previousUserID);
        PlayerPrefs.Save();
    }
}
