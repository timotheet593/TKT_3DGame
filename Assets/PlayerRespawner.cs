using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
    private Vector3 startPosition;

    // Set this in the Inspector or change the value here
    public float fallThreshold = -15f;

    void Start()
    {
        // Save initial spawn position
        startPosition = transform.position;
    }

    void Update()
    {
        // Check if the player's Y position is below the threshold
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        Debug.Log("Respawn triggered!");

        // Reset the player's position
        transform.position = startPosition;

        // If there's a CharacterController, reset its velocity by disabling/enabling it
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
            cc.enabled = true;
        }
    }
}