using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DeveloperMode : MonoBehaviour
{
    public List<GameObject> gameObjectsToControl; // Kontrol edilecek GameObject'lerin listesi
    public Toggle toggle; // Kontrole ba�l� olacak Toggle

    void Start()
    {
        // Toggle'�n de�erindeki de�i�iklikleri dinle
        toggle.onValueChanged.AddListener(ToggleGameObjects);
    }

    void ToggleGameObjects(bool isOn)
    {
        // T�m GameObject'lerin setActive durumunu Toggle'�n durumuna g�re ayarla
        foreach (GameObject obj in gameObjectsToControl)
        {
            if (obj != null) // Null kontrol�
            {
                obj.SetActive(isOn);
            }
        }
    }
}
