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
    int randomizer;
    State state;
    [SerializeField] States states;

    List<State> allPossibleQuestions;

    void Start()
    {
     //  GenerateNumberOfQuestionsList();
        allPossibleQuestions = states.GetStates();
        QuestionRandomizer();
    }

    void Update()
    {

    }
    private void GenerateNumberOfQuestionsList()
    {
        for (int i = 0; i < questionGeneratorListLength; i++)
        {
            questionGeneratorList.Add(i);
        }
    }
    private void QuestionRandomizer()
    {
        for (int i = 0; i < questionGeneratorListLength; i++)
        {
            var questionPicked = Random.Range(0, allPossibleQuestions.Count);
            state = allPossibleQuestions[questionPicked];
            questionList.Add(state);
            allPossibleQuestions.Remove(state);
            Debug.Log($"Picked Question : {questionList[i]}");
        }
    }
}
