using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question",fileName = "New question")]
public class QuestionScriptObject : ScriptableObject
{
   [TextArea(2,4)]
   [SerializeField] string question = "Nhap cau hoi vao day";
   [SerializeField] string[] answers = new string[4];
   [SerializeField] int correctAnswerIndex = 2;

    public string GetQuestion()
    {
        return question;
    }
    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }
}

public class Test
{
    QuestionScriptObject question;
    void TestA()
    {
        string questionText = question.GetQuestion();
        int correctAnswerIndex = question.GetCorrectAnswerIndex();
    }
}