using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText; // hien thi noi dung cau hoi len UI 
    QuestionScriptObject currentQuestion; // nap noi dung vo cau hoi
    [SerializeField] List<QuestionScriptObject> questions = new List<QuestionScriptObject>();

    [Header("Answers")]
    [SerializeField] GameObject[] answerButton; // hien thi noi dung, hinh anh, tuong tac voi cau tra loi
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header("Sprite")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Image timerImage;
    Unity.Mathematics.Random rand = new Unity.Mathematics.Random();

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    
    [Header("Timer")]
    Timer timer;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;
    public bool isComplete;
    void Awake()
    {
        timer = FindObjectOfType<Timer>();              // FindObjectOfType thuong danh cho .cs tu tao
        scoreKeeper = FindObjectOfType<ScoreKeeper>(); //FindObjectOfType thuong danh cho .cs tu tao
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    private void Update()
    {

        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion == true)
        {
            if (progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }

            hasAnsweredEarly = false;
            DisplayNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1); //-1 thay vi index la truong hop nguoi dung ko chon dap an
            ButtonState(false);
        }
        
    }

    void DisplayNextQuestion()
    {
        if (questions.Count > 0)
        {
            
            ButtonState(true);
            GetRandomQuestion();
            ChangeSprite();
            DisplayQuestion();
            scoreKeeper.IncrementQuestionsSeen();
        }
    }

    
    void GetRandomQuestion()
    {
       int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if (questions.Contains(currentQuestion)) 
        {
            questions.Remove(currentQuestion); 
        }
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();
        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
      
    }

    public void OnChooseAnswer(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        ButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score" + scoreKeeper.CalculateScore().ToString() + "%";
        progressBar.value++;
        
    }   

    public void DisplayAnswer(int index)
    {
        Button button = GetComponent<Button>();
        scoreKeeper.IncrementQuestionsSeen();
        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "correct";
            ButtonState(true);
            Image image = answerButton[index].GetComponent<Image>();
            image.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswer();
           
           
        }
        else
        {

            string answer = currentQuestion.GetAnswer(currentQuestion.GetCorrectAnswerIndex());
            questionText.text = "The correct answer is: " + answer;
            ButtonState(false);
            Image image = answerButton[currentQuestion.GetCorrectAnswerIndex()].GetComponent<Image>();
            image.sprite = correctAnswerSprite;
            
        }
    }

    void ButtonState(bool state)
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Button button = answerButton[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    public void ChangeSprite()
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Image image = answerButton[i].GetComponent<Image>();
            image.sprite = defaultAnswerSprite;
        }
    }
}



