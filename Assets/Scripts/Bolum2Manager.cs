using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bolum2Manager : MonoBehaviour
{
    public GameObject PanelBaslangic;
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel5;
    public GameObject Panel6;
    public GameObject Panel7;

    public GameObject Tooltip1;
    public GameObject Tooltip2;
    public GameObject Tooltip3;

    public Button BackButton;

    private void Start()
    {
        StartCoroutine(PlaySoundWithDelay());
    }

    private IEnumerator PlaySoundWithDelay()
    {
        yield return new WaitForSeconds(4); // 7 saniye bekle
        AudioManager.instance.Play("Baslangic");
    }

    public void KodOkundu()
    {
        Panel1.SetActive(false);
        PanelBaslangic.SetActive(false);
        Panel2.SetActive(true);
        AudioManager.instance.Play("g2");
        Debug.Log("1.kutu etiketi okundu ve tablet paneli deðiþtirildi");
        Tooltip1.SetActive(false);
        Tooltip2.SetActive(false);
    }

    public void KodOkundu2()
    {
        Tooltip2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(true);
        AudioManager.instance.Play("g4");
        Debug.Log("2.kutu etiketi okundu");
    }

    public void KodOkundu3()
    {
        Tooltip3.SetActive(false);
        Panel5.SetActive(false);
        Panel6.SetActive(true);
        AudioManager.instance.Play("g6");
        Debug.Log("3.kutu etiketi okundu");
    }

    public void BaslatButon()
    {
        Tooltip1.SetActive(true);
        PanelBaslangic.SetActive(false);
        Panel1.SetActive(true);
        AudioManager.instance.Play("g1");
        Debug.Log("Bölüm baþlatýldý");
    }

    public void AAlanSoket()
    {
        Tooltip2.SetActive(true);
        Panel2.SetActive(false);
        Panel3.SetActive(true);
        AudioManager.instance.Play("g3");
        Debug.Log("A rafýna kutu býrakýldý");
    }
    public void FAlanSoket()
    {
        Tooltip3 .SetActive(true);
        Panel4.SetActive(false);
        Panel5.SetActive(true);
        AudioManager.instance.Play("g5");
        Debug.Log("F rafýna kutu býrakýldý");
    }
    public void MAlanSoket()
    {
        
        Panel6.SetActive(false);
        BackButton.interactable = false;
        Panel7.SetActive(true);
        AudioManager.instance.Play("Tebrikler");
        Debug.Log("M rafýna kutu býrakýldý");
    }

    public void Logver(string Log)
    {
        Debug.Log(Log);
    }
}
