using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{ // D�nd�rme s�releri
    public float rotateDuration = 5.0f;
    public float waitDuration = 2.0f;
    public float targetAngle = 170.0f;
    public float firstAngle = 10;

    void Start()
    {
        // Coroutine ba�lat
        StartCoroutine(RotateCameraCoroutine());
    }

    IEnumerator RotateCameraCoroutine()
    {
        while (true)
        {
            // �lk d�nd�rme: 0'dan targetAngle'ye
            yield return RotateToAngle(targetAngle, rotateDuration);

            // Belirtilen s�re kadar bekle
            yield return new WaitForSeconds(waitDuration);

            // �kinci d�nd�rme: targetAngle'den 0 dereceye
            yield return RotateToAngle(firstAngle, rotateDuration);

            // Belirtilen s�re kadar bekle
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

        // Son hedef a��ya tam olarak ula�
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, targetAngle, transform.eulerAngles.z);
    }
}
