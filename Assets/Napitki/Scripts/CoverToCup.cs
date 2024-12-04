using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoverToCup : MonoBehaviour
{
    public GameObject cover;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cover")){
            Destroy(other.gameObject);
            cover.SetActive(true);
        }
    }
}
