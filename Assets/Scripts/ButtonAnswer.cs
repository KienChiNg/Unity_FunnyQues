using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// [System.Serializable]
public class ButtonAnswer : MonoBehaviour
{
    // public static ButtonAnswer
    public Button answerBtn;
    public Text answerTxt;
    public void setAnswerText(string content){
        answerTxt.text = content;
    }
}
