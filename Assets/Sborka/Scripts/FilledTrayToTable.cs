using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilledTrayToTable : MonoBehaviour
{
    [SerializeField] private Transform snapPoint;
    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Tray")){
            other.transform.position = snapPoint.transform.position;
            other.transform.rotation = snapPoint.transform.rotation;
            snapPoint.GetComponent<SnapPoint>().SetIsOccupied(true, other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Tray")){
            snapPoint.GetComponent<SnapPoint>().SetIsOccupied(false, null);
        }
    }
}
