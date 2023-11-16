using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class QuizUI : Singleton<QuizUI>
{
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] AnswerInfo[] answerButtons;
    [SerializeField] GameObject correct;
    [SerializeField] GameObject incorrect;
    [SerializeField] GameObject endGamePanel;
    Image image;
    int correctAnswersCount;

    public int CorrectAnswers => correctAnswersCount;

    protected override void Awake()
    {
        base.Awake();
        image = GetComponent<Image>();
    }

    void OnEnable()
    {
        foreach(var answer in answerButtons) 
        {
            answer.OnAnswer += OnAnswerClick;
        }
    }

    void OnDisable()
    {
        foreach (var answer in answerButtons)
        {
            answer.OnAnswer -= OnAnswerClick;
        }
    }

    void OnAnswerClick(AnswerInfo answer)
    {
        if (Quiz.Instance.Counter < Quiz.Instance.Questions.Count)
        {
            if (answer.Answer.IsCorrect)
            {
                correct.SetActive(true);
                correctAnswersCount++;
            }
            else
            {
                incorrect.SetActive(true);
            }
        }
        else
        {
            if (answer.Answer.IsCorrect) correctAnswersCount++;
            endGamePanel.SetActive(true);
        }
    }


    public void SetImage(Sprite sprite) => image.sprite = sprite;

    public void SetQuestion(string question) => this.question.text = question;
    
    public void SetAnswers(IReadOnlyCollection<Answer> answers)
    {
        int counter = 0;
        foreach(var answer in answers)
        {
            if (counter < answerButtons.Length)
            {
                answerButtons[counter].SetAnswer(answer);
                counter++;
            }
        }
    }

    public void ResetCorrectAnswerCount() => correctAnswersCount = 0;
}
