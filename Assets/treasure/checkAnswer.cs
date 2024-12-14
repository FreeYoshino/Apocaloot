using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class checkAnswer : MonoBehaviour
{
    public GameObject successful;
    public GameObject fail;
    public GameObject treasureQA;
    private bool isneartreasure = false;
    public QuestionBank questionBank; // 題庫資產
    public GameObject dialogueBox;    // 對話框
    public TextMeshProUGUI questionText; // 顯示題目的文本
    public TextMeshProUGUI[] answerButtons;
    private QuestionData currentQuestion;


    public void DisplayRandomQuestion()
    {


        dialogueBox.SetActive(true); // 顯示對話框

        // 顯示隨機題目
        int randomIndex = Random.Range(0, questionBank.questions.Length);
        currentQuestion = questionBank.questions[randomIndex];
        questionText.text = currentQuestion.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < currentQuestion.answers.Length)
            {
                answerButtons[i].gameObject.SetActive(true);
                answerButtons[i].text = currentQuestion.answers[i];
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void CheckAnswer(int answerIndex)
    {


        if (answerIndex == currentQuestion.correctAnswerIndex)
        {

            Debug.Log("獲得寶物！");
            successful.SetActive(true);
            fail.SetActive(false);
            // 在這裡執行獎勳或其他邏輯

        }
        else
        {

            Debug.Log("沒獲得寶物！");
            successful.SetActive(false);
            fail.SetActive(true);
            // 在這裡執行懲罰或其他邏輯

        }


    }

   
}
