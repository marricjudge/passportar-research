using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introductionbutton : MonoBehaviour
{
    public void ChangeSceneToPreQ()
    {
        SceneManager.LoadScene("pre-questionnaire");
    }
}
