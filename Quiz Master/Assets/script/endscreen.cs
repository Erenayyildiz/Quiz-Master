using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endscreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finish;
    scorekeeper Score;


    void Awake()
    {
        Score = FindObjectOfType<scorekeeper>();
    }

    public void FinalScore()
    {
        finish.text = "Congratulations! \n You Score " + Score.CalculateScore() + "%";
    }



}
