using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UygulamaBitir : MonoBehaviour
{
    public void MarkApplicationComplete(int level)
    {
        // Ka��nc� levelin uygulamas� ise level indexe o say�y� gir
        PlayerPrefs.SetInt("ApplicationComplete_Level" + level, 1);
        PlayerPrefs.Save();
        Debug.Log(level + ". level tamamlama butonuna bas�ld�.");
    }
}
