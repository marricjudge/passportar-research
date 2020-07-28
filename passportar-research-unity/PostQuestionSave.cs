using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostQuestionSave : MonoBehaviour
{
    public Dropdown Q1, Q2, Q3, Q4;
    public Text Q5;
    public string Q1Answer, Q2Answer, Q3Answer, Q4Answer, Q5Answer;

    void Update()
    {
        Q1Answer = Q1.options[Q1.value].text;
        Q2Answer = Q2.options[Q2.value].text;
        Q3Answer = Q3.options[Q3.value].text;
        Q4Answer = Q4.options[Q4.value].text;
        Q5Answer = Q5.text;

        PlayerPrefs.SetString("Q1Answer", Q1Answer);
        PlayerPrefs.SetString("Q2Answer", Q2Answer);
        PlayerPrefs.SetString("Q3Answer", Q3Answer);
        PlayerPrefs.SetString("Q4Answer", Q4Answer);
        PlayerPrefs.SetString("Q5Answer", Q5Answer);
        PlayerPrefs.Save();
    }
}
