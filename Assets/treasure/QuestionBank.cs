using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuestionBank", menuName = "Quiz/QuestionBank")]
public class QuestionBank : ScriptableObject
{
    public QuestionData[] questions; // 題目列表
}

[System.Serializable]
public class QuestionData
{
    public string questionText; // 題目內容
    public string[] answers;    // 答案選項
    public int correctAnswerIndex; // 正確答案的索引
}