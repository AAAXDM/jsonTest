using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Question
{
    [SerializeField] string question;
    [SerializeField] Answer[] answers;
    [SerializeField] string background;

    public string QuestionText => question;
    public string BackgroundText => background;
    public IReadOnlyCollection<Answer> Answers => answers;
}

[Serializable]
public class Answer
{
    [SerializeField] string text;
    [SerializeField] bool correct;

    public string AnswerText => text;
    public bool IsCorrect => correct;
}

[Serializable]
public class QuestionsList
{
   [SerializeField] Question[] questions;

    public IReadOnlyCollection<Question> Questions => questions;
    public int Count => questions.Length;

    public Question GetQuestion(int index)
    {
        if(index < questions.Length) return questions[index];
        else return null;
    }
}
