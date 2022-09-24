using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class question : ScriptableObject
{
    [TextArea(2,5)]
    [SerializeField] string Question = "New Question";
    [SerializeField] string[] Answers = new string[4];
    [SerializeField] int answerýndex;

    public string getquestion()
    {
        return Question;
    }
        
    public string getanswer(int index)
    {
        return Answers[index];
    }


    public int answer()
    {
        return answerýndex;
    }



}
