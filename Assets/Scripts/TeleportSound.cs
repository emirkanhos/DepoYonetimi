using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class TeleportSound : MonoBehaviour
{
    public AudioClip teleportSound; // I��nlanma sesi
    private AudioSource audioSource;
    private TeleportationProvider teleportationProvider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        teleportationProvider = GetComponent<TeleportationProvider>();
        if (teleportationProvider != null)
        {
            teleportationProvider.endLocomotion += OnTeleportEnd; // I��nlanma bitti�inde �a�r�l�r
        }
    }

    private void OnTeleportEnd(LocomotionSystem locomotionSystem)
    {
        // I��nlanma sesi �al
        if (teleportSound != null)
        {
            audioSource.PlayOneShot(teleportSound);
        }
    }

    private void OnDestroy()
    {
        if (teleportationProvider != null)
        {
            teleportationProvider.endLocomotion -= OnTeleportEnd;
        }
    }

}
