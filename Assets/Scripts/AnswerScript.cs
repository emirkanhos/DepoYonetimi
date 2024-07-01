using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public Color startColor;

    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void Answer()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManager.wrong();
        }
        StartCoroutine(ResetColor());
    }
    IEnumerator ResetColor()
    {
        // 0.5 saniye bekle
        yield return new WaitForSeconds(0.5f);

        // Ba�lang�� rengine geri d�nd�r
        GetComponent<Image>().color = startColor;
    }
}
