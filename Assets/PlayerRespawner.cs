using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
    private Vector3 startPosition;

    [Header("Respawn Settings")]
    public float fallThreshold = -7f;
    public Transform spawnPoint;     // Optional: override spawn position
    public AudioSource audioSource;  // Sound to play on wall hit

    void Start()
    {
        // Save initial spawn position if no spawnPoint assigned
        if (spawnPoint == null)
        {
            startPosition = transform.position;
        }
        else
        {
            startPosition = spawnPoint.position;
        }
    }

    void Update()
    {
        // Respawn if the player's Y position is below the threshold (no sound)
        if (transform.position.y < fallThreshold)
        {
            Respawn(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Respawn with sound only if hitting a wall tagged "DeathWall"
        if (other.CompareTag("DeathWall"))
        {
            Respawn(true);
        }
    }

    void Respawn(bool playSound)
    {
        Debug.Log("Respawn triggered!");

        // Play sound if requested
        if (playSound && audioSource != null)
        {
            audioSource.Play();
        }

        // Reset the player's position
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
            transform.position = startPosition;
            cc.enabled = true;
        }
        else
        {
            transform.position = startPosition;
        }
    }
}