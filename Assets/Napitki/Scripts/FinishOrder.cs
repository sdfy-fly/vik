using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishOrder : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private GameObject triggerZoneCola;
    [SerializeField] private GameObject triggerZoneFanta;
    [SerializeField] private GameObject triggerZoneSprite;
    [SerializeField] private GameObject triggerZoneColaIce;
    [SerializeField] private GameObject triggerZoneFantaIce;
    [SerializeField] private GameObject triggerZoneSpriteIce;

    public void CompleteOrder(){
        if(name == "кола со льдом"){
            List<GameObject> snapPoints = triggerZoneColaIce.GetComponent<CupToCloset>().getSnapPoints();
            foreach (var snapPoint in snapPoints){
                SnapPoint snapPointScript = snapPoint.GetComponent<SnapPoint>();
                if(snapPointScript.GetIsOccupied()){
                    Destroy(snapPointScript.GetOccupyingObject());
                    snapPointScript.SetIsOccupied(false, null);
                    gameObject.SetActive(false);
                    return;
                }
            }
        }
        if(name == "фанта со льдом"){
            List<GameObject> snapPoints = triggerZoneFantaIce.GetComponent<CupToCloset>().getSnapPoints();
            foreach (var snapPoint in snapPoints){
                SnapPoint snapPointScript = snapPoint.GetComponent<SnapPoint>();
                if(snapPointScript.GetIsOccupied()){
                    Destroy(snapPointScript.GetOccupyingObject());
                    snapPointScript.SetIsOccupied(false, null);
                    gameObject.SetActive(false);
                    return;
                }
            }
        }
        if(name == "спрайт со льдом"){
            List<GameObject> snapPoints = triggerZoneSpriteIce.GetComponent<CupToCloset>().getSnapPoints();
            foreach (var snapPoint in snapPoints){
                SnapPoint snapPointScript = snapPoint.GetComponent<SnapPoint>();
                if(snapPointScript.GetIsOccupied()){
                    Destroy(snapPointScript.GetOccupyingObject());
                    snapPointScript.SetIsOccupied(false, null);
                    gameObject.SetActive(false);
                    return;
                }
            }
        }
        if(name == "кола без льда"){
            List<GameObject> snapPoints = triggerZoneCola.GetComponent<CupToCloset>().getSnapPoints();
            foreach (var snapPoint in snapPoints){
                SnapPoint snapPointScript = snapPoint.GetComponent<SnapPoint>();
                if(snapPointScript.GetIsOccupied()){
                    Destroy(snapPointScript.GetOccupyingObject());
                    snapPointScript.SetIsOccupied(false, null);
                    gameObject.SetActive(false);
                    return;
                }
            }
        }
        if(name == "фанта без льда"){
            List<GameObject> snapPoints = triggerZoneFanta.GetComponent<CupToCloset>().getSnapPoints();
            foreach (var snapPoint in snapPoints){
                SnapPoint snapPointScript = snapPoint.GetComponent<SnapPoint>();
                if(snapPointScript.GetIsOccupied()){
                    Destroy(snapPointScript.GetOccupyingObject());
                    snapPointScript.SetIsOccupied(false, null);
                    gameObject.SetActive(false);
                    return;
                }
            }
        }
        if(name == "спрайт без льда"){
            List<GameObject> snapPoints = triggerZoneSprite.GetComponent<CupToCloset>().getSnapPoints();
            foreach (var snapPoint in snapPoints){
                SnapPoint snapPointScript = snapPoint.GetComponent<SnapPoint>();
                if(snapPointScript.GetIsOccupied()){
                    Destroy(snapPointScript.GetOccupyingObject());
                    snapPointScript.SetIsOccupied(false, null);
                    gameObject.SetActive(false);
                    return;
                }
            }
        }
    }

}
