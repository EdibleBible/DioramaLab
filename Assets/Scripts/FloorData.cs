using UnityEngine;

[CreateAssetMenu(fileName = "FloorData", menuName = "Custom/FloorData")]
public class FloorData : ScriptableObject
{
    public int currentFloor = 1; // The current floor number
}
