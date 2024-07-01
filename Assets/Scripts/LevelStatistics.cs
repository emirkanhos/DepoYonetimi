using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelStatistics : MonoBehaviour
{
    public TMP_Text statisticsText;
    public Dropdown levelDropdown;
    private int[] videoCounts = new int[7];
    private int[] uygulamaCounts = new int[7];
    private int[] testCounts = new int[7];

    private string defaultDropdownText = "Bölüm Seçiniz";

    private void Start()
    {
        LoadStatistics();
        levelDropdown.onValueChanged.AddListener(delegate
        {
            OnLevelDropdownValueChanged(levelDropdown);
        });
        ResetStatisticsPanel();
    }

    private void LoadStatistics()
    {
        for (int i = 0; i < videoCounts.Length; i++)
        {
            videoCounts[i] = PlayerPrefs.GetInt("VideoCount_Level" + i, 0);
            uygulamaCounts[i] = PlayerPrefs.GetInt("UygulamaCount_Level" + i, 0);
            testCounts[i] = PlayerPrefs.GetInt("TestCount_Level" + i, 0);
        }
    }

    private void SaveStatistics()
    {
        for (int i = 0; i < videoCounts.Length; i++)
        {
            PlayerPrefs.SetInt("VideoCount_Level" + i, videoCounts[i]);
            PlayerPrefs.SetInt("UygulamaCount_Level" + i, uygulamaCounts[i]);
            PlayerPrefs.SetInt("TestCount_Level" + i, testCounts[i]);
        }
        PlayerPrefs.Save();
    }

    public void OnLevelDropdownValueChanged(Dropdown change)
    {
        int selectedLevelIndex = levelDropdown.value;
        string selectedLevel = levelDropdown.options[selectedLevelIndex].text;

        string statistics = selectedLevel + "\n\n";
        statistics += "Video Giriþ Sayýsý: " + videoCounts[selectedLevelIndex] + "\n";
        statistics += "Uygulama Giriþ Sayýsý: " + uygulamaCounts[selectedLevelIndex] + "\n";
        statistics += "Test Giriþ Sayýsý: " + testCounts[selectedLevelIndex];

        statisticsText.text = statistics;
        if (levelDropdown.value == 0) // Eðer seçilen deðer "Bölüm Seçiniz" ise
        {
            statisticsText.text = defaultDropdownText;
        }
    }

    public void IncrementVideoCount(int levelIndex)
    {
        videoCounts[levelIndex]++;
        SaveStatistics();
    }

    public void IncrementUygulamaCount(int levelIndex)
    {
        uygulamaCounts[levelIndex]++;
        SaveStatistics();
    }

    public void IncrementTestCount(int levelIndex)
    {
        testCounts[levelIndex]++;
        SaveStatistics();
    }

    public void ResetStatisticsPanel()
    {
        levelDropdown.value = 0; // Dropdown'u "Bölüm Seçiniz" yapmak için 0 indeksine ayarla
        UpdateDropdownText();
    }

    private void UpdateDropdownText()
    {
        if (levelDropdown.value == 0) // Eðer seçilen deðer "Bölüm Seçiniz" ise
        {
            levelDropdown.options[levelDropdown.value].text = defaultDropdownText;
            statisticsText.text = defaultDropdownText;
        }
    }

    public void ResetStatistics()
    {
        for (int i = 0; i < videoCounts.Length; i++)
        {
            videoCounts[i] = 0;
            uygulamaCounts[i] = 0;
            testCounts[i] = 0;
            PlayerPrefs.SetInt("VideoCount_Level" + i, 0);
            PlayerPrefs.SetInt("UygulamaCount_Level" + i, 0);
            PlayerPrefs.SetInt("TestCount_Level" + i, 0);
        }
        PlayerPrefs.Save();
        ResetStatisticsPanel();
    }

    public string GetStatistics()
    {
        string stats = "";
        for (int i = 1; i < videoCounts.Length; i++)
        {
            stats += "Bölüm " + (i) + ":\n";
            stats += "Video: " + videoCounts[i] + "\n";
            stats += "Uygulama: " + uygulamaCounts[i] + "\n";
            stats += "Test: " + testCounts[i] + "\n";
            stats += "\n";
        }
        return stats;
    }
}
