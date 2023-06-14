using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSound : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float pitchMultiplier = 0.1f;
    public float minimumPitch = 0.1f;
    public float volumeMultiplier = 0.1f;
    public float minimumVolume = 0.1f;
    public float maximumVolume = 1f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = true;
    }

    private void Update()
    {
        // Get the ship's velocity from the PlayerMovement script
        Vector2 velocity = playerMovement.GetVelocity();

        // Calculate the pitch based on the ship's velocity
        float pitch = Mathf.Max(velocity.magnitude * pitchMultiplier, minimumPitch);

        // Calculate the volume based on the ship's velocity
        float volume = Mathf.Clamp(velocity.magnitude * volumeMultiplier, minimumVolume, maximumVolume);

        // Set the pitch and volume of the audio source
        audioSource.pitch = pitch;
        audioSource.volume = volume;
    }

    public void PlaySound()
    {
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource.Stop();
    }
}
