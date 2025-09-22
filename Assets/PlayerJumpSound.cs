using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerJumpSound : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Jump Sound")]
    public AudioClip jumpClip;

    void Start()
    {
        // Get the AudioSource component on the Player
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    void Update()
    {
        // Check for space bar (default jump button in Unity’s Input Manager)
        if (Input.GetButtonDown("Jump"))
        {
            PlayJumpSound();
        }
    }

    void PlayJumpSound()
    {
        if (jumpClip != null)
        {
            audioSource.PlayOneShot(jumpClip);
        }
    }
}