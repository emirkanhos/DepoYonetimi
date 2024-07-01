using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class Bolum3Manager : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel5;
    public GameObject Panel6;

    public GameObject LaptopPanel1;
    public GameObject LaptopPanel2;

    public GameObject[] tooltips;

    public TextMeshProUGUI bekleyiniz;

    public Button backButton;

    private void Start()
    {
        StartCoroutine(PlaySoundWithDelay());
    }

    private IEnumerator PlaySoundWithDelay()
    {
        yield return new WaitForSeconds(4); // 7 saniye bekle
        AudioManager.instance.Play("Baþlat");
    }
    public void LaptopPowerOn(){
        StartCoroutine(LaptopPowerOnCoroutine());
    }

    public void Kutu1()
    {
        Panel2.SetActive(false);
        Panel3.SetActive(true);
        AudioManager.instance.Play("g3");
    }

    public void Kutu2()
    {
        Panel3.SetActive(false);
        Panel4.SetActive(true);
        AudioManager.instance.Play("g4");
    }

    public void Kutu3()
    {
        Panel4.SetActive(false);
        Panel5.SetActive(true);
        AudioManager.instance.Play("g5");
    }

    public void Kutu4()
    {
        Panel5.SetActive(false);
        backButton.interactable = false;
        Panel6.SetActive(true);
        AudioManager.instance.Play("Tebrikler");
    }
    public void sesCal(string yazi)
    {
        AudioManager.instance.Play(yazi);

    }

    public void tooltipAc(int i)
    {
        tooltips[i-1].SetActive(true);
    }

    public void tooltipKapat(int i)
    {
        tooltips[i-1].SetActive(false);
    }

    IEnumerator LaptopPowerOnCoroutine(){
        LaptopPanel1.SetActive(true);
        
        string nokta = ".";
        for (int i = 0; i < 5; i++)
        {
            nokta += "."; // Nokta ekleyin
            bekleyiniz.text = "Gelen sipariþler düzenleniyor.\r\n\r\n\r\nLütfen bekleyin" + nokta; // Yazýyý güncelle
            yield return new WaitForSeconds(1f); // 1 saniye bekle
        }
        LaptopPanel1.SetActive(false);
        LaptopPanel2.SetActive(true);
        AudioManager.instance.Play("g2");

    }
}
