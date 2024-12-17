using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrayToTable : MonoBehaviour
{
    [SerializeField] private Transform snapPoint;
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Tray")){
            other.transform.position = snapPoint.transform.position;
            other.transform.rotation = Quaternion.Euler(-90, 0, 90);
        }
    }   
}
