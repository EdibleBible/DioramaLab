using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowButton : MonoBehaviour, IPointerClickHandler
{
    public TeleportCylinder elevator; // Reference to the elevator object
    public bool goesDown;

    public void OnPointerClick(PointerEventData eventData)
    {
        elevator.TeleportPlayer(goesDown);
    }
}
