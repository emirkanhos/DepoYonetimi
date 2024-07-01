using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bolum6Manager : MonoBehaviour
{
    public GameObject[] paneller;
    public GameObject[] targetIndicators;
    public GameObject[] urunler;
    public GameObject[] sepet;
    public GameObject[] soket;
    public GameObject[] tooltip;

    public GameObject LaptopPanel1;
    public GameObject LaptopPanel2;
    public GameObject LaptopIkmalYapildi;
    public TextMeshProUGUI bekleyiniz;

    public Button backButton;
    public Button gonderButton;

    private int sayac = 0;
    bool calistirildi = false;


    void Start()
    {
        StartCoroutine(PlaySoundWithDelay());
    }

    private IEnumerator PlaySoundWithDelay()
    {
        yield return new WaitForSeconds(4); // 5 saniye bekle
        AudioManager.instance.Play("Baþlat");
    }


    void Update()
    {
        if (sayac == 5 && !calistirildi)
        {
            gonderButton.interactable = true;
            calistirildi = true;
        }
    }

    public void KodOkundu1()
    {
        tooltip[0].SetActive(false);
        targetIndicators[0].SetActive(false);
        paneller[2].SetActive(false);
        paneller[3].SetActive(true);
        AudioManager.instance.Play("g3");
    }

    public void KodOkundu2()
    {
        tooltip[1].SetActive(false);
        paneller[4].SetActive(false);
        paneller[5].SetActive(true);
        AudioManager.instance.Play("g5");
    }

    public void Kutu1()
    {
        tooltip[1].SetActive(true);
        paneller[3].SetActive(false);
        paneller[4].SetActive(true);
        AudioManager.instance.Play("g4");
    }

    public void Kutu2()
    {
        paneller[5].SetActive(false);
        paneller[6].SetActive(true);
        AudioManager.instance.Play("Tebrikler");
    }

    public void SepeteEkle(int i)
    {
        i--;
        urunler[i].gameObject.SetActive(false);
        sepet[i].gameObject.SetActive(true);
        sayac++;
    }

    public void ikmalYap()
    {
        StartCoroutine(ScaleObject(3f));
        paneller[1].SetActive(false);
        paneller[2].SetActive(true);
        AudioManager.instance.Play("g2");
    }

    public void LaptopPowerOn()
    {
        StartCoroutine(LaptopPowerOnCoroutine());
    }

    IEnumerator LaptopPowerOnCoroutine()
    {
        LaptopPanel1.SetActive(true);
        string nokta = ".";
        for (int i = 0; i < 3; i++)
        {
            nokta += "."; // Nokta ekleyin
            bekleyiniz.text = "Ýkmal yapýlacak ürünler listesi düzenleniyor.\r\n\r\n\r\nLütfen bekleyiniz" + nokta; // Yazýyý güncelle
            yield return new WaitForSeconds(1f); // 1 saniye bekle
        }
        new WaitForSeconds(1f);
        nokta = ".";
        bekleyiniz.text = "Ýkmal yapýlacak ürünler listesi düzenleniyor.\r\n\r\n\r\nLütfen bekleyiniz" + nokta;
        for (int i = 0; i < 3; i++)
        {
            nokta += "."; // Nokta ekleyin
            bekleyiniz.text = "Ýkmal yapýlacak ürünler listesi düzenleniyor.\r\n\r\n\r\nLütfen bekleyiniz" + nokta; // Yazýyý güncelle
            yield return new WaitForSeconds(1f); // 1 saniye bekle
        }
        LaptopPanel1.SetActive(false);
        LaptopPanel2.SetActive(true);
    }

    IEnumerator ScaleObject(float duration)
    {
        Vector3 initialScale = Vector3.zero;
        Vector3 finalScale = Vector3.one;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            LaptopIkmalYapildi.transform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        LaptopIkmalYapildi.transform.localScale = finalScale;
    }
    public void sesCal(string yazi)
    {
        AudioManager.instance.Play(yazi);
    }
}
