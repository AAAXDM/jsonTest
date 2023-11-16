using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI count;
    [SerializeField] GameObject startMenu;
    string text;

    private void Awake() => text = count.text;
            
    void OnEnable() => count.text += QuizUI.Instance.CorrectAnswers.ToString();

    private void OnDisable() => count.text = text;      
    
    public void GoToStartMenu()
    {
        startMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
