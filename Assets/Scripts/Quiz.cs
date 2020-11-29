using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionTextComponent;    
    [SerializeField] int questionGeneratorListLength = 90;
    [SerializeField] State startingState;

    List<int> questionGeneratorList = new List<int>();
    List<State> questionList = new List<State>();
    State state;

    State randomizer;
    [SerializeField] States states;
    List<State> allPossibleQuestions;

    void Start()
    {
        allPossibleQuestions = states.GetStates();
        QuestionRandomizer();
    }

    void Update()
    {

    }
    private void QuestionRandomizer()
    {
        for (int i = 0; i < questionGeneratorListLength; i++)
        {
            var questionPicked = Random.Range(0, allPossibleQuestions.Count);
            randomizer = allPossibleQuestions[questionPicked];
            questionList.Add(randomizer);
            allPossibleQuestions.Remove(randomizer);
            Debug.Log($"Picked Question : {questionList[i]}");
        }
    }
    public void GoToNextQuestion()
    {
        for(int i = 0; i < questionGeneratorListLength; i++)
        {
            state = questionList[i];
            questionTextComponent.text = state.GetQuestionState();
        }
    }
}
