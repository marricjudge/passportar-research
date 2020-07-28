using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreQuestionSave : MonoBehaviour
{
    public Dropdown PreQ1, PreQ2, PreQ4, PreQ7;
    public Text PreQ3, PreQ6;
    public string PreQ1Ans, PreQ2Ans, PreQ3Ans, PreQ4Ans, PreQ5Ans, PreQ6Ans, PreQ7Ans;

    void Update()
    {
        PreQ1Ans = PreQ1.options[PreQ1.value].text;
        PreQ2Ans = PreQ2.options[PreQ2.value].text;
        PreQ3Ans = PreQ3.text.ToString();
        PreQ4Ans = PreQ4.options[PreQ4.value].text;
        PreQ6Ans = PreQ6.text.ToString();
        PreQ7Ans = PreQ7.options[PreQ7.value].text;

        PlayerPrefs.SetString("PreQ1Ans", PreQ1Ans);
        PlayerPrefs.SetString("PreQ2Ans", PreQ2Ans);
        PlayerPrefs.SetString("PreQ3Ans", PreQ3Ans);
        PlayerPrefs.SetString("PreQ4Ans", PreQ4Ans);
        PlayerPrefs.SetString("PreQ6Ans", PreQ6Ans);
        PlayerPrefs.SetString("PreQ7Ans", PreQ7Ans);
        PlayerPrefs.Save();
    }
}
