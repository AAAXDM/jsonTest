using UnityEngine;


public class Quiz : Singleton<Quiz>
{
    [SerializeField]TextAsset JSONText;
    QuizUI uI;
    QuestionsList questions;
    string path;
    int counter = 0;

    public int Counter => counter;
    public QuestionsList Questions => questions;

    override protected void Awake()
    {
        base.Awake();
        uI = FindObjectOfType<QuizUI>();
    }

    void Start()
    {
        path = Application.dataPath;
        questions = JsonUtility.FromJson<QuestionsList>(JSONText.text);
    }

    void SetData()
    {
        string spritePath = path + questions.GetQuestion(counter).BackgroundText;
        Sprite sprite = JpgToSpriteConvert.LoadNewSprite(spritePath);
        uI.SetQuestion(questions.GetQuestion(counter).QuestionText);
        uI.SetImage(sprite);
        uI.SetAnswers(questions.GetQuestion(counter).Answers);
        counter++;
    }

    public void SetDataToUI()
    {
        if (counter < questions.Count)
        {
            SetData();
        }
        else
        {
            counter = 0;
            QuizUI.Instance.ResetCorrectAnswerCount();
            SetData();
        }
    }
}

