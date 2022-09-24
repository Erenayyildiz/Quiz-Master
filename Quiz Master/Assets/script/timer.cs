using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float timecorrectanswer;

    public bool AnsweringQuestion;
    public float fillfraction;
    public bool loadnextqustion;

    float timervalue;


    void Update()
    {
        UpdateTimer();
    }

    public void canceltimer()
    {
        timervalue = 0;
    }
    
    void UpdateTimer()
    {
        timervalue -= Time.deltaTime;

        if(AnsweringQuestion)
        {
            if(timervalue > 0)
            {
                fillfraction = timervalue / time;
            }
            else
            {
                AnsweringQuestion = false;
                timervalue = timecorrectanswer;
            }
        }
        else
        {
            if(timervalue > 0)
            {
                fillfraction = timervalue / timecorrectanswer;
            }
            else
            {
                AnsweringQuestion=true;
                timervalue = time;
                loadnextqustion = true;
            }
        }
    }



}
