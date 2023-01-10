using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Ins;
    public TextMeshProUGUI timeTxt;
    public TextMeshProUGUI questionTxt;
    public ButtonAnswer[] buttonAnswers;    
    void Awake()
    {
        makeSingleton();
    }
    // void Start()
    // {
    //     shuffleAnswer();
    // }
    public void setTimeText(string content){
        timeTxt.text = content;
    }

    public void setQuestionText(string content){
        questionTxt.text = content;
    }

    public void shuffleAnswer(){
        if (buttonAnswers.Length > 0){
            for (int i = 0; i < buttonAnswers.Length; i++)
            {
                if (buttonAnswers[i]){
                    buttonAnswers[i].tag = "Untagged";
                }
            }
            int randInd = Random.Range(0,buttonAnswers.Length);
            if (buttonAnswers[randInd]){
                buttonAnswers[randInd].tag = "CorrectAns";
            }
        }
    }

    public void makeSingleton(){
        if(Ins == null){
            Ins = this;
        }else{
            Destroy(gameObject);
        }
    }
 }

