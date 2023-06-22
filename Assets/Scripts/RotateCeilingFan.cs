using UnityEngine;

public class RotateCeilingFan : MonoBehaviour
{
    public float rotationSpeed = 30f; // Rotation speed in degrees per frame

    void Update()
    {
        // Rotate the object around the Z-axis
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
