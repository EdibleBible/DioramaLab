using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArrowButton : MonoBehaviour, IPointerClickHandler
{
    public TeleportCylinder elevator; // Reference to the elevator object
    public CameraRotation gameCamera;
    public bool goesDown;
    public float teleportationDuration;
    public FloorData floorData;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (goesDown)
        {
            case true:
                floorData.currentFloor--;
                break;
            case false:
                floorData.currentFloor++;
                break;
        }
        elevator.TeleportPlayer(goesDown, teleportationDuration);
        gameCamera.ChangeFloor(goesDown, teleportationDuration);
    }

    
}
