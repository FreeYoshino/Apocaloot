using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuestionBank", menuName = "Quiz/QuestionBank")]
public class QuestionBank : ScriptableObject
{
    public QuestionData[] questions; // �D�ئC��
}

[System.Serializable]
public class QuestionData
{
    public string questionText; // �D�ؤ��e
    public string[] answers;    // ���׿ﶵ
    public int correctAnswerIndex; // ���T���ת�����
}