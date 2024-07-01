using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class GameProgressManager : MonoBehaviour
{
    public Button[] levelButtons;
    public GameObject[] starGraphics; // Yýldýz görselleri
    public GameObject[] ticks; // Tik görselleri
    public GameObject[] crosses; // Çarpý görselleri
    public GameObject[] statisticsObjects;
    public TextMeshProUGUI progressText;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI PathText;
    public TMP_InputField nameInputField;

    private int totalStars = 18; // Toplam yýldýz sayýsý
    private bool[] starStates = new bool[18]; // Yýldýz durumlarý
    private string playerName = "";

    public LevelStatistics levelStatistics;

    void Start()
    {
        LoadProgress();
        UpdateLevelAccess();
        UpdateUI();
        CheckAllLevelsForCompletion();
        Debug.Log("GameProgresManager Baþladý");
    }

    void UpdateLevelAccess()
    {
        levelButtons[0].interactable = true;
        // Yýldýzlar doðrudan kontrol edilerek seviye butonlarý etkinleþtiriliyor
        if (starStates[0] && starStates[1] && starStates[2]) // Örneðin, 3 yýldýz toplandýðýnda bir sonraki seviyenin kilidini açabilirsiniz.
        {
            levelButtons[1].interactable = true; // Örneðin, seviye 2'nin kilidini açmak için
        }
        if (starStates[3] && starStates[4] && starStates[5])
        {
            levelButtons[2].interactable = true;
        }
        if (starStates[6] && starStates[7] && starStates[8])
        {
            levelButtons[3].interactable = true;
        }
        if (starStates[9] && starStates[10] && starStates[11])
        {
            levelButtons[4].interactable = true;
        }
        if (starStates[12] && starStates[13] && starStates[14])
        {
            levelButtons[5].interactable = true;
        }
    }

    //Kullanýlmayan Eski kod
    bool AreRequiredStarsCollected(int levelIndex)
    {
        int requiredStars = (levelIndex - 1) * 3;  // Önceki seviyelerde gereken yýldýz sayýsý
        int collectedStars = 0;
        for (int i = 0; i < requiredStars; i++)
        {
            if (starStates[i]) collectedStars++;
        }
        return collectedStars >= requiredStars;
    }

    //Kullanýlmayan Eski kod
    bool CheckStarsForLevelUnlock(int levelIndex)
    {
        int requiredStars = (levelIndex - 1) * 3; // Her seviye için önceki tüm yýldýzlar alýnmalý
        int count = 0;
        for (int i = 0; i < requiredStars; i++)
        {
            if (starStates[i])
            {
                count++;
            }
            Debug.Log("Seviye " + levelIndex + " için gereken yýldýz sayýsý: " + requiredStars + ", Kazanýlan yýldýz sayýsý: " + count);
        }
        return count == requiredStars;
    }

    void UpdateUI()
    {
        Debug.Log("UpdateUI baþladý");
        int openedStars = 0;
        for (int i = 0; i < starStates.Length; i++)
        {
            starGraphics[i].SetActive(starStates[i]);
            if (starStates[i])
            {
                ticks[i].SetActive(true);
                crosses[i].SetActive(false);
                openedStars++;
            }
            else
            {
                ticks[i].SetActive(false);
                crosses[i].SetActive(true);
            }
        }

        float progress = (float)openedStars / totalStars * 100f;
        progressText.text = "Ýlerleme Yüzdesi: " + progress.ToString("F0") + "%";
    }

    public void CompleteStar(int index)
    {
        if (index < 0 || index >= starStates.Length) return;
        starStates[index] = true;
        PlayerPrefs.SetInt("Star_" + (index + 1), 1);
        PlayerPrefs.Save();
        UpdateUI();
        UpdateLevelAccess();
        Debug.Log("Star " + index + " completed.");
    }

    private void CompleteLevel(int level)
    {
        if (level < 1 || level >= levelButtons.Length) return;
        PlayerPrefs.SetInt("Level_" + (level + 1), 1);
        PlayerPrefs.Save();
        UpdateLevelAccess();
        Debug.Log("Level " + level + " completed.");
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        for (int i = 0; i < starStates.Length; i++)
        {
            starStates[i] = false;
        }
        for (int i = 1; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
        levelButtons[0].interactable = true;
        UpdateUI(); // UI güncellemek için çaðrý yap
        if (levelStatistics != null)
        {
            levelStatistics.ResetStatistics(); // LevelStatistics sýnýfýndaki verileri sýfýrla
        }
        
        Debug.Log("Sýfýrlama yapýldý");
    }

    void LoadProgress()
    {
        for (int i = 0; i < starStates.Length; i++)
        {
            starStates[i] = PlayerPrefs.GetInt("Star_" + (i + 1), 0) == 1;
            Debug.Log("Yýldýz " + (i + 1) + " durumu: " + starStates[i]);
        }
        UpdateUI();
    }

    void CheckAllLevelsForCompletion()
    {
        int levels = levelButtons.Length;
        Debug.Log("Uygulama tamamlanma kontrol baþlatýldý ve uzunluk: " + levels);
        for (int i = 1; i <= levels; i++)
        {
            CheckApplicationComplete(i);
            Debug.Log(i + ". level kontrol ediliyor");
        }
    }

    public void CheckApplicationComplete(int level)
    {
        if (PlayerPrefs.GetInt("ApplicationComplete_Level" + level, 0) == 1)
        {
            CompleteStar((level - 1) * 3 + 1);
            PlayerPrefs.SetInt("ApplicationComplete_Level" + level, 0);
            PlayerPrefs.Save();
            Debug.Log(((level - 1) * 3 + 1) + ".yýldýz açýldý"); ;
        }
    }

    public void OnConfirmNameButtonClicked()
    {
        playerName = nameInputField.text;
        if (!string.IsNullOrEmpty(playerName))
        {
            nameText.text = ("Kullanýcý adý: " + playerName + "\n\n Verileri sýfýrlamak istiyor musunuz ?").ToString();
            Debug.Log("Ýsim onaylandý: " + playerName);
            statisticsObjects[0].SetActive(false);
            statisticsObjects[1].SetActive(true);
        }
        else
        {
            Debug.LogWarning("Lütfen önce isminizi girin ve onaylayýn.");
        }
    }

    public void OnSaveStatsButtonClicked(bool check)
    {
        if (!string.IsNullOrEmpty(playerName))
        {
            string path = Application.persistentDataPath + "/" + playerName + "_stats.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Tarih ve Saat: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                writer.WriteLine(playerName+ ", isimli kullanýcýnýn istatistikleri: ");
                writer.WriteLine();

                writer.WriteLine("Ýstatistikler:");
                writer.WriteLine(progressText.text);
                writer.WriteLine();

                writer.WriteLine("Level Ýstatistikleri:");
                writer.WriteLine(levelStatistics.GetStatistics());
            }
            Debug.Log("Ýstatistikler kaydedildi: " + path);
            PathText.text = ("Kaydedilen yol:\n" + path);
            if (check)
            {
                ResetProgress();
            }
            nameInputField.text = "";
            statisticsObjects[1].SetActive(false);
            statisticsObjects[2].SetActive(true);
        }
    }
}
