using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionTextComponent;    
    [SerializeField] TextMeshProUGUI[] answersTextComponent;
    private int questionGeneratorListLength = 90;
    private int selectedAnswer = 0;
    private int correctAnswer = 0;
    private int currentQuestion = 0;
    [HideInInspector] public List<bool> selectedAnswers;

    [SerializeField] State startingState;
    [HideInInspector] public List<State> questionList = new List<State>();

    [SerializeField] SetActiveToggle setActiveToggle;
    State state;
    State randomizer;
    [SerializeField] States states;
    List<State> allPossibleQuestions;

    [SerializeField] Results results;

    void Start()
    {
        state = startingState;
        UpdateState();
        allPossibleQuestions = states.GetStates();
    }
    
    private void QuestionRandomizer()
    {
        for (int i = 0; i < questionGeneratorListLength; i++)
        {
            var questionPicked = Random.Range(0, allPossibleQuestions.Count);
            randomizer = allPossibleQuestions[questionPicked];
            questionList.Add(randomizer);
            allPossibleQuestions.Remove(randomizer);
        }
    }
    public void ClickedNextQuestionButton()
    {
        if (state.name == "Initial State")
        {
            InitialQuestion();
            return;
        }
        if(selectedAnswer == correctAnswer)
        {
            selectedAnswers.Add(true);
        }
        if (selectedAnswer != correctAnswer)
        {
            selectedAnswers.Add(false);
        }
        if (selectedAnswer != 0)
        GoToNextQuestion();
        else
        Debug.Log("You must select an answer to continue");
    }
    private void GoToNextQuestion()
    {
        currentQuestion++;
        if (currentQuestion >= questionList.Count)
        {
            results.DisablePreviousGUI();
            return;
        }
        state = questionList[currentQuestion];
        UpdateState();
    }
    private void UpdateState()
    {
        questionTextComponent.text = state.GetQuestionState();
        for (int i = 0; i < 4; i++)
        {
            answersTextComponent[i].text = state.GetAnswerState(i);   
        }
        correctAnswer = state.GetCorrectAnswer();
    }
    public void ToggleActivated()
    {
        StartCoroutine(UpdateSelectedQuestion());
    }
    IEnumerator UpdateSelectedQuestion()
    {
        yield return new WaitForSeconds(0.1f);
        selectedAnswer = setActiveToggle.toggleNumber;
        Debug.Log(selectedAnswer);
    }
    private void InitialQuestion()
    {
        if (selectedAnswer == 0)
        {
            Debug.Log("You must select an amount.");
            return;
        }
        else if (selectedAnswer == 1)
        questionGeneratorListLength = 10;
        else if (selectedAnswer == 2)
        questionGeneratorListLength = 25;
        else if (selectedAnswer == 3)
        questionGeneratorListLength = 50;
        else if (selectedAnswer == 4)
        questionGeneratorListLength = 90;

        QuestionRandomizer();
        state = questionList[currentQuestion];
        UpdateState();
    }
}
