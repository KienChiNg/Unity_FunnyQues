using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int timePerQuestion;
    int m_time;
    int m_correctCount;
    void Awake()
    {
        m_time = timePerQuestion;
    }
    void Start()
    {
        m_correctCount = 1;
        setTimeCoutingDown();
        createQuestion();
        StartCoroutine(timeCountingDown());
    }

    void Update()
    {

    }
    public void Replay()
    {
        // Debug.Log("Halooo");
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit(){
        // Debug.Log("Exit");
        Application.Quit();
    }

    public void createQuestion()
    {
        QuestionData questionData = QuestionManager.Ins.getRandomQuestion();
        if (questionData != null)
        {
            string[] wrongAns = new string[] { questionData.answer1, questionData.answer2, questionData.answer3 };
            UIManager.Ins.shuffleAnswer();
            UIManager.Ins.setQuestionText(questionData.question);
            var temp = UIManager.Ins.buttonAnswers;
            int idx = 0;
            if (temp.Length > 0)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    int indAns = i;
                    if (temp[i].CompareTag("CorrectAns"))
                    {
                        temp[i].setAnswerText(questionData.correctAns);
                    }
                    else
                    {
                        temp[i].setAnswerText(wrongAns[idx]);
                        idx++;

                    }
                    temp[i].answerBtn.onClick.RemoveAllListeners();
                    temp[i].answerBtn.onClick.AddListener(delegate { checkCorrectAnsEvent(temp[indAns]); });
                }
            }
        }
    }

    public void setTimeCoutingDown()
    {
        if (m_time >= 10)
        {
            UIManager.Ins.setTimeText(("00:" + m_time));
        }
        else
        {
            UIManager.Ins.setTimeText(("00:0" + m_time));
        }
    }
    public void checkCorrectAnsEvent(ButtonAnswer btnAns)
    {
        if (btnAns.CompareTag("CorrectAns"))
        {
            if (m_correctCount == QuestionManager.Ins.questions.Length)
            {
                Dialog.Ins.setNotiFiText("Bạn đã chiến thắng");
                Dialog.Ins.showDialogState(true);
            }
            else
            {
                createQuestion();
                m_time = timePerQuestion;
                m_correctCount++;
            }
            // Debug.Log("Tl dung");
        }
        else
        {
            Dialog.Ins.setNotiFiText("Bạn đã thua cuộc");
            Dialog.Ins.showDialogState(true);
            StopAllCoroutines();
            // Debug.Log("Tl sai");
        }
    }
    IEnumerator timeCountingDown()
    {
        // UIManager.Ins.setTimeText(m_time);
        yield return new WaitForSeconds(1);
        if (m_time > 0)
        {
            m_time--;
            setTimeCoutingDown();
            StartCoroutine(timeCountingDown());
        }
        else
        {
            UIManager.Ins.setTimeText(("00:0" + m_time));
            Dialog.Ins.setNotiFiText("Bạn đã hết thời gian");
            Dialog.Ins.showDialogState(true);
            StopAllCoroutines();
        }
    }
}
