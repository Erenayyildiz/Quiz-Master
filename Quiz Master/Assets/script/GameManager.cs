using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    quiz Quiz;
    endscreen End;

    void Awake()
    {
        Quiz = FindObjectOfType<quiz>();
        End = FindObjectOfType<endscreen>();
    }
    void Start()
    {
        Quiz.gameObject.SetActive(true);
        End.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if(Quiz.isComplete)
        {
            Quiz.gameObject.SetActive(false);
            End.gameObject.SetActive(true);
            End.FinalScore();
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }





}
