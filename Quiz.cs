using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    public Sprite questionImage;
    public string[] answers;
    public string correctAns;
    public string questionText;
    public string questionType;

    public bool IsCorrectAnswer(string selectedAns)
    {
        return selectedAns == correctAns;
    }

    void Awake()
    {
        if(questionType == null)
        {
            questionType = "";
        }
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = questionImage;
        gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = questionType;
        gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = questionText;

        for (int i = 1; i <= 4; i++)
        {
            gameObject.transform.GetChild(3).GetChild(i - 1).GetChild(0).gameObject.GetComponent<Text>().text = answers[i - 1];
        }
    }
}
