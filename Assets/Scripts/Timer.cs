using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowAnswer = 10f;
    float timerValue;
    public float fillFraction;
    public bool loadNextQuestion;
    public bool isAnsweringQuestion;
    
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }

            else {
                isAnsweringQuestion = false;
                timerValue = timeToShowAnswer;
                
            }
        }

        else
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
             else
            {
              
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
        Debug.Log(isAnsweringQuestion + " " +timerValue + " " + fillFraction);
    }
}
