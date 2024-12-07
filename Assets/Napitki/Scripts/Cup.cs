using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField] private GameObject cola;
    [SerializeField] private GameObject fanta;
    [SerializeField] private GameObject sprite;
    [SerializeField] private GameObject cover;

    public GameObject getColaObject(){
        return cola;
    }
    public GameObject getFantaObject(){
        return fanta;
    }
    public GameObject getSpriteObject(){
        return sprite;
    }
    public GameObject getCoverObject(){
        return cover;
    }
}
