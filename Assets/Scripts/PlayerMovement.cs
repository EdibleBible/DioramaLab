using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed
    public float rotationSpeed = 180f; // Player rotation speed
    public int currentFloor = 1;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input for player movement
        float forwardInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        // Move the player forward and backward
        Vector3 movement = transform.forward * forwardInput * moveSpeed * Time.deltaTime;
        characterController.Move(movement);

        // Rotate the player
        float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
