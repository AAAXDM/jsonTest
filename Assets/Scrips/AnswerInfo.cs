using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class AnswerInfo : MonoBehaviour
{
    Answer answer;
    TextMeshProUGUI buttonText;

    public Answer Answer => answer;

    public Action<AnswerInfo> OnAnswer;

    private void Awake() => buttonText = GetComponentInChildren<TextMeshProUGUI>();
   
    public void SetAnswer(Answer answer)
    {
        this.answer = answer;
        buttonText.text = answer.AnswerText;
    }

    public void OnClick() => OnAnswer.Invoke(this);
        
}
