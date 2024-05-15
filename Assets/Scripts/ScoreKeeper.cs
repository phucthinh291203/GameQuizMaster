using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int CorrectAnswer = 0;
    int QuestionsSeen = 0;

    public int GetCorrectAnswer()
    {
        return CorrectAnswer;
    }
    public int GetQuestionsSeen()
    {
        return QuestionsSeen; 
    }
    public void IncrementCorrectAnswer()
    {
        CorrectAnswer++;
    }
    public void IncrementQuestionsSeen()
    {
        QuestionsSeen++;
    }
    public int CalculateScore()
    {
        return Mathf.RoundToInt(CorrectAnswer/ (float)QuestionsSeen * 100); //mathf la chuyen tu float thanh int
    }
}
