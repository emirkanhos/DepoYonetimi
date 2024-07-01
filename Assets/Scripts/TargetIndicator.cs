using UnityEngine;
using TMPro;

public class TargetIndicator : MonoBehaviour
{
    // Kullan�c�n�n ba��na ba�l� kamera
    public Transform playerCamera;

    // Hedef g�stergesinin sabit kalaca�� pozisyon
    //public Vector3 fixedPosition;

    // Uzakl�k metni i�in TMP_Text bile�eni
    public TMP_Text distanceText;

    // Hedef g�stergesinin 1 metreden daha yak�n oldu�u durumu kontrol etmek i�in e�ik de�eri
    public float visibilityThreshold = 1f;

    private Canvas canvas;

    void Start()
    {
        transform.position = gameObject.transform.position;
        canvas = GetComponentInChildren<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Canvas component not found under TargetIndicator. Make sure to attach a Canvas component to a child GameObject.");
        }
    }

    void Update()
    {
        // Hedef g�stergesini sabit pozisyonda tut
        //transform.position = fixedPosition;

        // Hedef g�stergesini kullan�c�ya do�ru d�nd�r
        transform.LookAt(2 * transform.position - playerCamera.position);

        // Hedef g�stergesi ile kamera aras�ndaki mesafeyi hesapla
        float distance = Vector3.Distance(transform.position, playerCamera.position);

        // Mesafeyi ekranda g�ster
        if (distanceText != null)
        {
            distanceText.text = distance.ToString("F0") + " m"; // Virg�lden sonras�n� g�stermemek i�in "F0" kullan�l�r
        }

        // Hedef g�stergesi 1 metreden daha yak�nsa g�r�n�rl���n� kapat
        if (distance < visibilityThreshold)
        {
            SetVisibility(false);
        }
        else
        {
            SetVisibility(true);
        }
    }

    // G�r�n�rl��� ayarlamak i�in bir fonksiyon
    void SetVisibility(bool visible)
    {
        // Hedef g�stergesinin g�r�n�rl���n� ve aktifli�ini ayarla
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = visible;
        }
        if (distanceText != null)
        {
            distanceText.enabled = visible;
        }

        // Canvas'�n g�r�n�rl���n� ayarla
        if (canvas != null)
        {
            canvas.enabled = visible;
        }
    }
}
