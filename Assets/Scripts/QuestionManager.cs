using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Ins;
    public QuestionData[] questions;
    List<QuestionData> m_questionData;
    QuestionData m_curQuestion;

    public QuestionData CurQuestion { get => m_curQuestion; set => m_curQuestion = value; }
    void Awake()
    {
        m_questionData = questions.ToList();
        makeSingleton();
        // Debug.Log("Question" + getRandomQuestion().question);
    }
    public QuestionData getRandomQuestion(){
        if (m_questionData.Count > 0){
            int randInd = Random.Range(0, m_questionData.Count);
            m_curQuestion = m_questionData[randInd];
            m_questionData.RemoveAt(randInd);
        }
        return m_curQuestion;
    }

    public void makeSingleton(){
        if(Ins == null){
            Ins = this;
        }else{
            Destroy(gameObject);
        }
    }
}
