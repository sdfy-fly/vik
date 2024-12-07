using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CupToBottling : MonoBehaviour
{
    [SerializeField] private Transform snapPoint;
    private GameObject cup;
    private bool isInZone = false;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Cup")){
            cup = other.gameObject;
            isInZone = true;
            other.transform.position = snapPoint.position;
            other.transform.rotation = Quaternion.Euler(-90, 0, 90);
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Cup")){
            isInZone = false;
            cup = null;
        }
    }

    public bool isCupInZone(){
        return isInZone;
    }
    public GameObject getCup(){
        return cup;
    }
}
