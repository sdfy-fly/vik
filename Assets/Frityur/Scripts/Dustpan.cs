using UnityEngine;

public class Dustpan : MonoBehaviour
{
    public GameObject potatoFreeScoop;
    public GameObject potatoDerScoop;
    public GameObject largePotatoFree;
    public GameObject averagePotatoFree;
    public GameObject smallPotatoFree;
    public GameObject largePotatoDer;
    public GameObject averagePotatoDer;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("LargePotato")){
            if(potatoFreeScoop.activeSelf){
                potatoFreeScoop.SetActive(false);
                Vector3 position = other.transform.position;
                Quaternion rotation = other.transform.rotation;
                Instantiate(largePotatoFree, position, rotation);
                Destroy(other.gameObject);
            }
            if(potatoDerScoop.activeSelf){
                potatoDerScoop.SetActive(false);
                Vector3 position = other.transform.position;
                Quaternion rotation = other.transform.rotation;
                Instantiate(largePotatoDer, position, rotation);
                Destroy(other.gameObject);
            }
            Debug.Log("LargePotato");
        }
        if(other.CompareTag("AveragePotato")){
            if(potatoFreeScoop.activeSelf){
                potatoFreeScoop.SetActive(false);
                Vector3 position = other.transform.position;
                Quaternion rotation = other.transform.rotation;
                Instantiate(averagePotatoFree, position, rotation);
                Destroy(other.gameObject);
            }
            if(potatoDerScoop.activeSelf){
                potatoDerScoop.SetActive(false);
                Vector3 position = other.transform.position;
                Quaternion rotation = other.transform.rotation;
                Instantiate(averagePotatoDer, position, rotation);
                Destroy(other.gameObject);
            }
            Debug.Log("AveragePotato");
        }
        if(other.CompareTag("SmallPotato")){
            if(potatoFreeScoop.activeSelf){
                potatoFreeScoop.SetActive(false);
                Vector3 position = other.transform.position;
                Quaternion rotation = other.transform.rotation;
                Instantiate(smallPotatoFree, position, rotation);
                Destroy(other.gameObject);
            }
            Debug.Log("SmallPotato");
        }
    }
}
