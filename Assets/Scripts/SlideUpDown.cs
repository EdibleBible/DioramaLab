using UnityEngine;
using DG.Tweening;

public class SlideUpDown : MonoBehaviour
{
    public float slideDistance = 5f; // Distance to slide up and down
    public float slideDuration = 1f; // Duration of each slide
    public Ease ease;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;

        // Start the sliding animation
        SlideAnimation();
    }

    private void SlideAnimation()
    {
        // Calculate the target position for sliding up and down
        Vector3 targetPosition = initialPosition + Vector3.up * slideDistance;

        // Slide up and down continuously using DOTween
        transform.DOMove(targetPosition, slideDuration)
            .SetEase(ease)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
