using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bolum5manager : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;

    private bool kutu1, kutu2, kutu3, kutu4, bitti;


    private void Start()
    {
        StartCoroutine(PlaySoundWithDelay());
    }

    private IEnumerator PlaySoundWithDelay()
    {
        yield return new WaitForSeconds(4); // 5 saniye bekle
        AudioManager.instance.Play("Baþlat");
    }

    public void soket1()
    {
        if (kutu1 != true)
        {
            kutu1 = true;
            Debug.Log("kutu1 true");
        }
    }

    public void soket2() 
    {
        if (kutu2 != true)
        {
            kutu2 = true;
            Debug.Log("kutu2 true");
        }
    }

    public void soket3()
    {
        if (kutu3 != true)
        {
            kutu3 = true;
            Debug.Log("kutu3 true");
        }
    }
    public void soket4()
    {
        if (kutu4 != true)
        {
            kutu4 = true;
            Debug.Log("kutu4 true");
        }
    }

    private void Update()
    {
        if (kutu1 && kutu2 && kutu3 && kutu4 && !bitti) 
        {
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            bitti=true;
            AudioManager.instance.Play("Tebrikler");
        }
        
    }
    public void sesCal(string yazi)
    {
        AudioManager.instance.Play(yazi);

    }
}
