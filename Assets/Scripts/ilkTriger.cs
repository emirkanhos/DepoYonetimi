using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ilkTriger : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel4;
    public GameObject Panel5;
    public GameObject Panel7;
    public GameObject Panel8;

    public GameObject TrigerAlaný;
    public GameObject Socket;


    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kutu-1"))
        {
            Debug.Log("1.Kutu masaya kondu");
            TrigerAlaný.SetActive(false);
            Socket.SetActive(true);
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            AudioManager.instance.Play("g2");
        }
        if (other.CompareTag("Kutu-2"))
        {
            Debug.Log("2.Kutu masaya kondu");
            TrigerAlaný.SetActive(false);
            Socket.SetActive(true);
            Panel4.SetActive(false);
            Panel5.SetActive(true);
            AudioManager.instance.Play("g5");
        }
        if (other.CompareTag("Kutu-3"))
        {
            Debug.Log("3.Kutu masaya kondu");
            TrigerAlaný.SetActive(false);
            Socket.SetActive(true);
            Panel7.SetActive(false);
            Panel8.SetActive(true);
            AudioManager.instance.Play("g5");
        }
    }
}
