using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI endText;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void ShowFinalScore()
    {
        endText.text = "Congratulations!\n You scored: "
            + scoreKeeper.CalculateScore().ToString() + "%"; 
    }
}
