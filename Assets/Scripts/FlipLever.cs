using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class FlipLever : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public GameObject[] objectsToInstantiate; // Array of objects to instantiate
    public List<Transform> spawnPositions; // List of spawn positions
    public List<float> volumes;
    public List<AudioClip> deathSounds;

    private float delay = 1f; // Delay before object instantiation
    private AudioSource audioSource;
    private int range;

    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        range = objectsToInstantiate.Length - 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("FlipLever"); // Trigger the animation transition
        StartCoroutine(InstantiateObjectCoroutine());

    }

    private IEnumerator InstantiateObjectCoroutine()
    {
        yield return new WaitForSeconds(delay);

        int randomIndex = Random.Range(0, range);
        GameObject objectToInstantiate = objectsToInstantiate[randomIndex];

        int randomPositionIndex = Random.Range(0, spawnPositions.Count);
        Transform spawnPosition = spawnPositions[randomPositionIndex];

        Instantiate(objectToInstantiate, spawnPosition.position, Quaternion.identity);

        yield return new WaitForSeconds(6f);

        audioSource.PlayOneShot(deathSounds[randomIndex], volumes[randomIndex]);
        range = objectsToInstantiate.Length;
    }
}
