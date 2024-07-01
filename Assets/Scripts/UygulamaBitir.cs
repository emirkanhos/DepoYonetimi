using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UygulamaBitir : MonoBehaviour
{
    public void MarkApplicationComplete(int level)
    {
        // Kaçýncý levelin uygulamasý ise level indexe o sayýyý gir
        PlayerPrefs.SetInt("ApplicationComplete_Level" + level, 1);
        PlayerPrefs.Save();
        Debug.Log(level + ". level tamamlama butonuna basýldý.");
    }
}
