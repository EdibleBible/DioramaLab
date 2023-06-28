using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitch : MonoBehaviour
{
    public List<Material> materials; // List of materials
    public GameObject affectedObject; // Object whose material will be switched

    private Renderer objectRenderer; // Renderer component of the affected object
    private int currentMaterialIndex = 0; // Index of the current material

    private void Start()
    {
        objectRenderer = affectedObject.GetComponent<Renderer>();

        if (objectRenderer == null)
        {
            Debug.LogError("Affected object does not have a Renderer component.");
        }
        else
        {
            UpdateMaterial();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enabled = true; // Enable the script when the player enters the collider
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enabled = false; // Disable the script when the player exits the collider
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchMaterial();
        }
    }

    private void SwitchMaterial()
    {
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Count;
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        objectRenderer.material = materials[currentMaterialIndex];
    }
}
