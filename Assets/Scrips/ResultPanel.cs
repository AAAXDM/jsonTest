using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    public void GoNext()
    {
        Quiz.Instance.SetDataToUI();
        gameObject.SetActive(false);
    }
}
