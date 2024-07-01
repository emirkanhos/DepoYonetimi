using UnityEngine;
using TMPro;

public class TargetIndicator : MonoBehaviour
{
    // Kullanýcýnýn baþýna baðlý kamera
    public Transform playerCamera;

    // Hedef göstergesinin sabit kalacaðý pozisyon
    //public Vector3 fixedPosition;

    // Uzaklýk metni için TMP_Text bileþeni
    public TMP_Text distanceText;

    // Hedef göstergesinin 1 metreden daha yakýn olduðu durumu kontrol etmek için eþik deðeri
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
        // Hedef göstergesini sabit pozisyonda tut
        //transform.position = fixedPosition;

        // Hedef göstergesini kullanýcýya doðru döndür
        transform.LookAt(2 * transform.position - playerCamera.position);

        // Hedef göstergesi ile kamera arasýndaki mesafeyi hesapla
        float distance = Vector3.Distance(transform.position, playerCamera.position);

        // Mesafeyi ekranda göster
        if (distanceText != null)
        {
            distanceText.text = distance.ToString("F0") + " m"; // Virgülden sonrasýný göstermemek için "F0" kullanýlýr
        }

        // Hedef göstergesi 1 metreden daha yakýnsa görünürlüðünü kapat
        if (distance < visibilityThreshold)
        {
            SetVisibility(false);
        }
        else
        {
            SetVisibility(true);
        }
    }

    // Görünürlüðü ayarlamak için bir fonksiyon
    void SetVisibility(bool visible)
    {
        // Hedef göstergesinin görünürlüðünü ve aktifliðini ayarla
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = visible;
        }
        if (distanceText != null)
        {
            distanceText.enabled = visible;
        }

        // Canvas'ýn görünürlüðünü ayarla
        if (canvas != null)
        {
            canvas.enabled = visible;
        }
    }
}
