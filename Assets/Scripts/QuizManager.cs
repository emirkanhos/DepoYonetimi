using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<SorularVeCevaplar> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuestionTxt;
    public TextMeshProUGUI GOScoreText;

    int TotalQuestions = 0;
    public int score;

    public GameObject QuizPanel;
    public GameObject GOPanel;
    public GameObject WinPanel;

    private List<SorularVeCevaplar> originalQnA = new List<SorularVeCevaplar>();

    private void Start()
    {
        TotalQuestions = QnA.Count;
        GOPanel.SetActive(false);
        generateQuestion();
        foreach (SorularVeCevaplar soru in QnA)
        {
            originalQnA.Add(soru);
        }
    }

    public void retry()
    {
        // Score'u sýfýrla
        score = 0;
        // Sorularý ve cevaplarý tekrar yükle
        QnA.Clear();

        foreach (SorularVeCevaplar soru in originalQnA)
        {
            QnA.Add(soru);
        }

        // Yeniden baþlat
        generateQuestion();
        foreach (GameObject button in options)
        {
            button.GetComponent<Image>().color = button.GetComponent<AnswerScript>().startColor;
        }
    }

    void GameOver()
    {
        QuizPanel.SetActive(false);
        GOPanel.SetActive(true);
        GOScoreText.text = score + " / " + TotalQuestions;
    }

    void Kazandin()
    {
        QuizPanel.SetActive(false);
        WinPanel.SetActive(true);
    }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
        
            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;

            SetAnswers();
        }
        else if(score==TotalQuestions)
        {
            Debug.Log("Full doðru");
            Kazandin();
        }
        else
        {
            Debug.Log("Out of questions");
            GameOver();
        }
    }
}
