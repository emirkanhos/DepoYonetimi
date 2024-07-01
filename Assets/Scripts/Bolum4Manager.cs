using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bolum4Manager : MonoBehaviour
{
    public GameObject PanelB;
    public GameObject Panel1;
    public GameObject Panel2;
    public Button backButton;
    public GameObject kutu1;
    public GameObject kutu2;
    public GameObject kutu3;
    public GameObject kutu4;
    public GameObject kutu5;
    public GameObject kutu6;
    public GameObject kutu7;
    public GameObject kutu8;
    public GameObject kutua;
    public GameObject kutub;
    public GameObject kutuc;
    public GameObject kutud;

    public GameObject Tooltip1;
    public GameObject Tooltip2;
    public GameObject Tooltip3;
    public GameObject Tooltip4;

    private bool box1, box2, box3, box4;
    bool calistirildi = false;


    private void Start()
    {
        StartCoroutine(PlaySoundWithDelay());
    }

    private IEnumerator PlaySoundWithDelay()
    {
        yield return new WaitForSeconds(4); // 7 saniye bekle
        AudioManager.instance.Play("Baþlat");
    }


    public void KodOkundu()
    {

        Tooltip1.SetActive(true);
    }
    public void KodOkundu2()
    {
        Tooltip2.SetActive(true);
    }
    public void KodOkundu3()
    {
        Tooltip3.SetActive(true);
    }
    public void KodOkundu4()
    {
        Tooltip4.SetActive(true);
    }

    private void Update()
    {
        if (box1 && box2 && box3 && box4 && !calistirildi)
        {
            Panel1.SetActive(false);
            backButton.interactable = false;
            Panel2.SetActive(true);
            AudioManager.instance.Play("Tebrikler");
            Debug.Log("bitti");
            calistirildi=true;
        }
    }
    public void kutukapa()
    {
        if (!box1)
        {
            kutu1.SetActive(false);
            kutu2.SetActive(true);
            kutua.SetActive(false);
            Tooltip1.SetActive(false );
            box1 = true;
        }
    }
    public void kutukapa2()
    {
        if (!box2)
        {
            kutu3.SetActive(false);
            kutu4.SetActive(true);
            kutub.SetActive(false);
            Tooltip2.SetActive(false);
            box2 = true;
        }
    }
    public void kutukapa3()
    {
        if (!box3)
        {
            kutu5.SetActive(false);
            kutu6.SetActive(true);
            kutuc.SetActive(false);
            Tooltip3.SetActive(false);
            box3 = true;
        }
    }
    public void kutukapa4()
    {
        if (!box4)
        {
            kutu7.SetActive(false);
            kutu8.SetActive(true);
            kutud.SetActive(false);
            Tooltip4.SetActive(false);
            box4 = true;
        }
    }

    public void sesCal(string yazi)
    {
        AudioManager.instance.Play(yazi);

    }
}
