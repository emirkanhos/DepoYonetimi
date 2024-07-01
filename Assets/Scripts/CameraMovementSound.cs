using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class CameraMovementSound : MonoBehaviour
{
    public AudioSource footstepAudioSource;  // Ayak sesi AudioSource bileþeni
    public float footstepDelay = 0.5f;       // Adýmlar arasýnda bekleme süresi (saniye)
    public float movementSpeed = 3f;         // Hareket hýzý

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

        // Hareket ediyorsa ve yürüme sesi çalmak için yeterli süre geçtiyse
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
            // Hareket etmiyorsa veya ses çalýyorsa sesi durdur
            if (footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Stop();
            }
        }
    }

    Vector2 GetJoystickInput()
    {
        // Joystick deðerlerini al
        Vector2 joystickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        return joystickInput;
    }
}
