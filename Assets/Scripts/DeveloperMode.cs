using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DeveloperMode : MonoBehaviour
{
    public List<GameObject> gameObjectsToControl; // Kontrol edilecek GameObject'lerin listesi
    public Toggle toggle; // Kontrole baðlý olacak Toggle

    void Start()
    {
        // Toggle'ýn deðerindeki deðiþiklikleri dinle
        toggle.onValueChanged.AddListener(ToggleGameObjects);
    }

    void ToggleGameObjects(bool isOn)
    {
        // Tüm GameObject'lerin setActive durumunu Toggle'ýn durumuna göre ayarla
        foreach (GameObject obj in gameObjectsToControl)
        {
            if (obj != null) // Null kontrolü
            {
                obj.SetActive(isOn);
            }
        }
    }
}
