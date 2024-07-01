using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{ // Döndürme süreleri
    public float rotateDuration = 5.0f;
    public float waitDuration = 2.0f;
    public float targetAngle = 170.0f;
    public float firstAngle = 10;

    void Start()
    {
        // Coroutine baþlat
        StartCoroutine(RotateCameraCoroutine());
    }

    IEnumerator RotateCameraCoroutine()
    {
        while (true)
        {
            // Ýlk döndürme: 0'dan targetAngle'ye
            yield return RotateToAngle(targetAngle, rotateDuration);

            // Belirtilen süre kadar bekle
            yield return new WaitForSeconds(waitDuration);

            // Ýkinci döndürme: targetAngle'den 0 dereceye
            yield return RotateToAngle(firstAngle, rotateDuration);

            // Belirtilen süre kadar bekle
            yield return new WaitForSeconds(waitDuration);
        }
    }

    IEnumerator RotateToAngle(float targetAngle, float duration)
    {
        float startAngle = transform.eulerAngles.y;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float currentAngle = Mathf.Lerp(startAngle, targetAngle, elapsed / duration);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentAngle, transform.eulerAngles.z);
            yield return null;
        }

        // Son hedef açýya tam olarak ulaþ
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, targetAngle, transform.eulerAngles.z);
    }
}
