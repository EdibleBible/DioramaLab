using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class TeleportCylinder : MonoBehaviour
{
    public GameObject elevatorPanel;
    public TeleportCylinder elevatorHigher; // Reference to the other teleport cylinder
    public TeleportCylinder elevatorLower; // Reference to the other teleport cylinder
    public GameObject player; // Reference to the player object
    public AudioClip audioClip; // The audio clip to play
    public float volume = 1f; // The volume of the audio clip

    private bool playerEntered = false;
    private float fadeDuration;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void TeleportPlayer(bool direction, float teleportationDuration)
    {
        if (playerEntered)
        {
            fadeDuration = teleportationDuration * 0.6f;
            audioSource.PlayOneShot(audioClip, volume);
            StartCoroutine(TeleportationCoroutine(direction));
        }
    }
    private IEnumerator TeleportationCoroutine(bool direction)
    {
        elevatorPanel.SetActive(false);

        yield return new WaitForSeconds(fadeDuration);

        player.SetActive(false);
        // player.transform.position = goesUp ? elevatorHigher.transform.position : elevatorLower.transform.position;
        switch (direction)
        {
            case false:
                player.transform.position = elevatorHigher.transform.position;
                break;
            case true:
                player.transform.position = elevatorLower.transform.position;
                break;
        }

        yield return null;

        player.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = true;
            elevatorPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = false;
            elevatorPanel.SetActive(false);
        }
    }
}
