using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    private bool isOccupied = false;
    private GameObject occupyingObject = null;

    public bool GetIsOccupied()
    {
        return isOccupied;
    }

    public void SetIsOccupied(bool occupied, GameObject obj)
    {
        isOccupied = occupied;
        occupyingObject = obj;
    }

    public GameObject GetOccupyingObject()
    {
        return occupyingObject;
    }
}
