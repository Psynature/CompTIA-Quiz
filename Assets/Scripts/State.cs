﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10,30)][SerializeField] string questionText;
    [TextArea(5,30)][SerializeField] string correctAnswerDescription;
    [TextArea(1,4)][SerializeField] string[] answers;
    [SerializeField] int correctAnswer;

    public string GetCorrectAnswerDescription()
    {
        return correctAnswerDescription;
    }
    public string GetQuestionState()
    {
        return questionText;
    }
    public string GetAnswerState(int i)
    {
        return answers[i];
    }
    public int GetCorrectAnswer()
    {
        return correctAnswer;
    }
}
