using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerMovement : MonoBehaviour
{
    public ActionBasedController leftController;
    public ActionBasedController rightController;
    public AudioSource footstepAudioSource;
    public AudioClip footstepClip;
    private float stepInterval = 0.13f; // Sürekli adým sesinin aralýðý

    private Vector3 previousPosition;
    private float stepTimer;

    void Start()
    {
        if (footstepAudioSource == null)
        {
            footstepAudioSource = gameObject.AddComponent<AudioSource>();
        }

        previousPosition = (leftController.transform.position + rightController.transform.position) / 2;
        stepTimer = stepInterval;
    }

    void Update()
    {
        // Controller hareketini kontrol et
        Vector3 leftControllerPosition = leftController.transform.position;
        Vector3 rightControllerPosition = rightController.transform.position;
        Vector3 currentPosition = (leftControllerPosition + rightControllerPosition) / 2;

        float distanceMoved = Vector3.Distance(previousPosition, currentPosition);

        // Eðer oyuncu belirli bir mesafe hareket ettiyse
        if (distanceMoved > 0.1f)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                footstepAudioSource.PlayOneShot(footstepClip);
                stepTimer = stepInterval;
            }

            previousPosition = currentPosition;
        }
    }
}

