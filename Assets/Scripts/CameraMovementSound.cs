using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class CameraMovementSound : MonoBehaviour
{
    public AudioSource footstepAudioSource;  // Ayak sesi AudioSource bile�eni
    public float footstepDelay = 0.5f;       // Ad�mlar aras�nda bekleme s�resi (saniye)
    public float movementSpeed = 3f;         // Hareket h�z�

    private Vector3 lastPosition;
    private float nextFootstepTime;

    void Start()
    {
        lastPosition = transform.position;

        if (footstepAudioSource == null)
        {
            Debug.LogError("Footstep AudioSource is not assigned!");
        }
    }

    void Update()
    {
        Vector2 joystickInput = GetJoystickInput();
        Vector3 movement = new Vector3(joystickInput.x, 0, joystickInput.y);

        // Kamera hareket ettirme
        transform.Translate(movement * movementSpeed * Time.deltaTime);

        // Hareket ediyorsa ve y�r�me sesi �almak i�in yeterli s�re ge�tiyse
        if (movement.magnitude > 0 && Time.time >= nextFootstepTime)
        {
            if (!footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Play();
            }
            nextFootstepTime = Time.time + footstepDelay;
        }
        else
        {
            // Hareket etmiyorsa veya ses �al�yorsa sesi durdur
            if (footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Stop();
            }
        }
    }

    Vector2 GetJoystickInput()
    {
        // Joystick de�erlerini al
        Vector2 joystickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        return joystickInput;
    }
}
