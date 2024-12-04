using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopPotatoes : MonoBehaviour
{
    public GameObject potatoFreePacking;
    public GameObject potatoDerPacking;
    public GameObject potatoFreeScoop;
    public GameObject potatoDerScoop;
    public GameObject widePartScoop;
    public string potato;
    private void OnTriggerEnter(Collider other){
        if(other.gameObject == widePartScoop && !potatoFreeScoop.activeSelf && !potatoDerScoop.activeSelf){
            if(potato == "free" && potatoFreePacking.activeSelf){
                potatoFreePacking.SetActive(false);
                potatoFreeScoop.SetActive(true);
            }
            if(potato == "der" && potatoDerPacking.activeSelf){
                potatoDerPacking.SetActive(false);
                potatoDerScoop.SetActive(true);
            }
        }
    }
}
