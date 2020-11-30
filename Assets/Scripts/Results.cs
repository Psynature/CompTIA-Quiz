using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Results : MonoBehaviour
{
    [SerializeField] GameObject quizObject, resultsObject, questionResultsPrefab;
    [SerializeField] RectTransform resultsRect;
    Quiz quiz;

    private void Start()
    {
        quiz = FindObjectOfType<Quiz>();
        if (quiz == null)
            Debug.Log("quiz object could not be found.");
    }
    public void DisablePreviousGUI()
    {
        quizObject.SetActive(false);
        EnableResultsGUI();
    }
    private void EnableResultsGUI()
    {
        resultsObject.SetActive(true);
        for (int i = 0; i < quiz.selectedAnswers.Count; i++)
        {
            var yPos = 500f - i * 100f;

            var questionResults = Instantiate(
                questionResultsPrefab,
                new Vector2(
                    transform.localPosition.x,
                    yPos
                ),
                Quaternion.identity) as GameObject;
            SetResultsParent(questionResults);
            
            var questionNumber = questionResults.transform.Find("Question Number").GetComponent<TMP_Text>();
            questionNumber.text = (i + 1).ToString();

            var questionText = questionResults.transform.Find("Question Text").GetComponent<TMP_Text>();
            questionText.text = quiz.questionList[i].GetQuestionState();

            var correctAnswerDescription = questionResults.transform.Find("Answer Text").GetComponent<TMP_Text>();
            correctAnswerDescription.text = quiz.questionList[i].GetCorrectAnswerDescription();

            var borderImage = questionResults.transform.Find("Border").GetComponent<Image>();
            if (quiz.selectedAnswers[i] == true)
            {
                borderImage.color = new Color(0,1,0);
            }
            if (quiz.selectedAnswers[i] == false)
            {
                borderImage.color = new Color(1,0,0);
            }

            Debug.Log(quiz.selectedAnswers[i]);
        }
    }

    private void SetResultsParent(GameObject questionResults)
    {
        questionResults.transform.SetParent(resultsRect, false);
    }
}
