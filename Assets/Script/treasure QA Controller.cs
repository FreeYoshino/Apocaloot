using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class treasureQAController : MonoBehaviour
{
    public GameObject treasureQA;
    private bool isneartreasure = false;
    public QuestionBank questionBank; // 題庫資產
    public GameObject dialogueBox;    // 對話框
    public TextMeshProUGUI questionText; // 顯示題目的文本
    //public TextMeshProUGUI[] answerButtons; // 顯示選項的按鈕
    public TextMeshProUGUI[] answerButtons;  // 改為 Button 類型
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
        Time.timeScale = 0;
    }
    
    public void CheckAnswer(int answerIndex)
    {
        

        if (answerIndex == currentQuestion.correctAnswerIndex)
        {
           
            Debug.Log("獲得寶物！");
           
            // 在這裡執行獎勳或其他邏輯

        }
        else
        {
           
            Debug.Log("沒獲得寶物！");
            // 在這裡執行懲罰或其他邏輯

        }
        Time.timeScale = 1;
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isneartreasure = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isneartreasure = false;
            treasureQA.SetActive(false);
        }
    }
    void Update()
    {
        if (isneartreasure == true && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("開啟寶箱");
            treasureQA.SetActive(true);
            DisplayRandomQuestion();
        }
    }
}
