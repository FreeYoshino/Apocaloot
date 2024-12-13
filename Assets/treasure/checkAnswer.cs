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
    public QuestionBank questionBank; // �D�w�겣
    public GameObject dialogueBox;    // ��ܮ�
    public TextMeshProUGUI questionText; // ����D�ت��奻
    public TextMeshProUGUI[] answerButtons;
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
    }

    public void CheckAnswer(int answerIndex)
    {


        if (answerIndex == currentQuestion.correctAnswerIndex)
        {

            Debug.Log("��o�_���I");
            successful.SetActive(true);
            fail.SetActive(false);
            // �b�o�̰�������Ψ�L�޿�

        }
        else
        {

            Debug.Log("�S��o�_���I");
            successful.SetActive(false);
            fail.SetActive(true);
            // �b�o�̰����g�@�Ψ�L�޿�

        }


    }

   
}
