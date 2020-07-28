using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCreditsAndBack : MonoBehaviour
{
    public void loadCredits()
    {
        SceneManager.LoadScene("credits");
    }

    public void goBack()
    {
        SceneManager.LoadScene("thankyou");
    }
}

