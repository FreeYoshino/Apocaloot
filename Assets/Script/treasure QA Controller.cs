using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class treasureQAController : MonoBehaviour
{
    public GameObject treasureQA;
    private bool isneartreasure = false;
    public QuestionBank questionBank; // �D�w�겣
    public GameObject dialogueBox;    // ��ܮ�
    public TextMeshProUGUI questionText; // ����D�ت��奻
    //public TextMeshProUGUI[] answerButtons; // ��ܿﶵ�����s
    public TextMeshProUGUI[] answerButtons;  // �אּ Button ����
    private QuestionData currentQuestion;
    
   
    public void DisplayRandomQuestion()
    {
        

        dialogueBox.SetActive(true); // ��ܹ�ܮ�

        // ����H���D��
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
           
            Debug.Log("��o�_���I");
           
            // �b�o�̰�������Ψ�L�޿�

        }
        else
        {
           
            Debug.Log("�S��o�_���I");
            // �b�o�̰����g�@�Ψ�L�޿�

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
            Debug.Log("�}���_�c");
            treasureQA.SetActive(true);
            DisplayRandomQuestion();
        }
    }
}
