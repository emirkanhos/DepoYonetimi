using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class TeleportSound : MonoBehaviour
{
    public AudioClip teleportSound; // Iþýnlanma sesi
    private AudioSource audioSource;
    private TeleportationProvider teleportationProvider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        teleportationProvider = GetComponent<TeleportationProvider>();
        if (teleportationProvider != null)
        {
            teleportationProvider.endLocomotion += OnTeleportEnd; // Iþýnlanma bittiðinde çaðrýlýr
        }
    }

    private void OnTeleportEnd(LocomotionSystem locomotionSystem)
    {
        // Iþýnlanma sesi çal
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
