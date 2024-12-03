using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinkeFree : MonoBehaviour
{
    public GameObject basketFree;
    public GameObject basketDer;
    public GameObject potatoFree;
    public GameObject potatoDer;
    public GameObject potatoFreePacking;
    public GameObject potatoDerPacking;

    private void OnTriggerEnter(Collider other){
        if (other.gameObject == basketFree && potatoFree.activeSelf && !potatoFreePacking.activeSelf){
            potatoFreePacking.SetActive(true);
            potatoFree.SetActive(false);
        }
        if (other.gameObject == basketDer && potatoDer.activeSelf && !potatoDerPacking.activeSelf){
            potatoDerPacking.SetActive(true);
            potatoDer.SetActive(false);
        }
    }
}
