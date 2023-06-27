using UnityEngine;
using UnityEngine.UI;

public class TeleportCylinder : MonoBehaviour
{
    public Material redMaterial;
    public Material greenMaterial;
    public GameObject elevatorPanel;
    public TeleportCylinder elevatorHigher; // Reference to the other teleport cylinder
    public TeleportCylinder elevatorLower; // Reference to the other teleport cylinder
    public GameObject player; // Reference to the player object
    private bool playerEntered = false;

    private void Update()
    {
    }

    public void TeleportPlayer(bool direction)
    {
        if (playerEntered)
        {
            player.SetActive(false);
            // player.transform.position = goesUp ? elevatorHigher.transform.position : elevatorLower.transform.position;
            switch (direction)
            {
                case true:
                    player.transform.position = elevatorHigher.transform.position;
                    break;
                case false:
                    player.transform.position = elevatorLower.transform.position;
                    break;
            }
            elevatorPanel.SetActive(false);
            GetComponent<Renderer>().material = greenMaterial;
            player.SetActive(true);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = true;
            elevatorPanel.SetActive(true);
            GetComponent<Renderer>().material = redMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = false;
            elevatorPanel.SetActive(false);
            GetComponent<Renderer>().material = greenMaterial;
        }
    }
}
