using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class quiz : MonoBehaviour
{
    [Header("Question")] 
    [SerializeField] TextMeshProUGUI questiontext;
    [SerializeField] List<question> questions = new List<question>();
    question Question;

    [Header ("Answers")]
    [SerializeField] GameObject[] answerbuttons;
    int correctanswerindex;
    public bool AnswerdEarly = true;

    [Header ("Button Colors")]
    [SerializeField] Sprite defaultanswersprite;
    [SerializeField] Sprite correctanswersprite;

    [Header ("Timer")]
    [SerializeField] Image timerýmage;
    timer Timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoretext;
    scorekeeper Scorekeeper;

    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;
    public bool isComplete;

    void Awake()
    {
        Timer = FindObjectOfType<timer>();
        Scorekeeper = FindObjectOfType<scorekeeper>();
        progressBar.value = 0;
        progressBar.maxValue = questions.Count;
    }

    void Update()
    {
        timerýmage.fillAmount = Timer.fillfraction;
        if(Timer.loadnextqustion)
        {
            if (progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }

            AnswerdEarly = false;
            GetNextQustion();
            Timer.loadnextqustion = false;
        }
        else if (!AnswerdEarly && !Timer.AnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    void AnswerSelected(int index)
    {
        AnswerdEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        Timer.canceltimer();
        scoretext.text = "Skor: " + Scorekeeper.CalculateScore()+ "%";
    }

    void DisplayAnswer(int index)
    {
        Image buttonýmage;

        if (index == Question.answer())
        {
            questiontext.text = "Doðru!";
            buttonýmage = answerbuttons[index].GetComponent<Image>();
            buttonýmage.sprite = correctanswersprite;
            Scorekeeper.IncrementCorrectAnswers();
        }
        else
        {
            correctanswerindex = Question.answer();
            string correctanswer = Question.getanswer(correctanswerindex);
            questiontext.text = "Yanlýþ!, Doðru Cevap = " + correctanswer;
            buttonýmage = answerbuttons[correctanswerindex].GetComponent<Image>();
            buttonýmage.sprite = correctanswersprite;
        }
    }

    void GetNextQustion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            progressBar.value++;
            Scorekeeper.IncrementQuestionSeen();
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        Question = questions[index];

        if(questions.Contains(Question))
        {
            questions.Remove(Question);
        }

    }

    void DisplayQuestion()
    {
        questiontext.text = Question.getquestion();

        for (int i = 0; i < answerbuttons.Length; i++)
        {
            TextMeshProUGUI buttontext = answerbuttons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttontext.text = Question.getanswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerbuttons.Length; i++)
        {
            Button button = answerbuttons[i].GetComponent<Button>();
            button.interactable = state;
        }

    }

    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerbuttons.Length; i++)
        {
            Image buttonimage = answerbuttons[i].GetComponent<Image>();
            buttonimage.sprite = defaultanswersprite;
        }
    }

}
