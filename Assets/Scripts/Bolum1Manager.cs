using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bolum1Manager : MonoBehaviour
{
    public GameObject Triger1;
    public GameObject Triger2;
    public GameObject Triger3;

    public GameObject Kutu1;
    public GameObject Kutu2;
    public GameObject Kutu3;

    public GameObject PanelBaslangic;
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel5;
    public GameObject Panel6;
    public GameObject Panel7;
    public GameObject Panel8;
    public GameObject Panel9;
    public GameObject Panel10;

    public GameObject SocketKýrmýzýAlan;
    public GameObject SocketYesilAlan;
    public GameObject SocketMaviAlan;

    public GameObject EtiketKirmizi;
    public GameObject EtiketYesil;
    public GameObject EtiketMavi;

    public GameObject Indicator1;
    public GameObject Indicator2;
    public GameObject Indicator3;

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

    public void BaslatButon()
    {
        Triger1.SetActive(true);
        Kutu1.SetActive(true);
        PanelBaslangic.SetActive(false);
        Panel1.SetActive(true);
        Indicator1.SetActive(true);
        AudioManager.instance.Play("g1");
        Debug.Log("Baþlat Butonuna Basýldý");
    }

    public void Indicator1Kapat()
    {
        Indicator1.SetActive(false);
    }

    public void Indicator2Kapat()
    {
        Indicator2.SetActive(false);
    }

    public void Indicator3Kapat()
    {
        Indicator3.SetActive(false);
    }

    public void IlkKutuSoketi()
    {
        Panel2.SetActive(false);
        Panel3.SetActive(true);
        SocketKýrmýzýAlan.SetActive(true);
        AudioManager.instance.Play("g3");
        Debug.Log("Birinci kutuya etiket eklendi");
    }

    public void IkinciKutuSoketi()
    {
        Panel5.SetActive(false);
        Panel6.SetActive(true);
        SocketYesilAlan.SetActive(true);
        AudioManager.instance.Play("g6");
        Debug.Log("Ýkinci kutuya etiket eklendi");
    }

    public void UcuncuKutuSoketi()
    {
        Panel8.SetActive(false);
        Panel9.SetActive(true);
        SocketMaviAlan.SetActive(true);
        AudioManager.instance.Play("g3");
        Debug.Log("Üçüncü kutuya etiket eklendi");
    }

    public void KirmiziAlanSoketi()
    {
        Panel3.SetActive(false);
        Panel4.SetActive(true);
        Kutu2.SetActive(true);
        Triger2.SetActive(true);
        Indicator2.SetActive(true);
        AudioManager.instance.Play("g4");
        Debug.Log("Kýrmýzý Alana Kutu Býrakýldý");
    }

    public void YesilAlanSoketi()
    {
        Panel6.SetActive(false);
        Panel7.SetActive(true);
        Kutu3.SetActive(true);
        Triger3.SetActive(true);
        Indicator3.SetActive(true);
        AudioManager.instance.Play("g7");
        Debug.Log("Yeþil Alana Kutu Býrakýldý");
    }

    public void MaviAlanSoketi()
    {
        Debug.Log("Mavi Alana kutu býrakýldý");
        Panel9.SetActive(false);
        BackButton.interactable = false;
        Panel10.SetActive(true);
        AudioManager.instance.Play("Tebrik");
    }
}
