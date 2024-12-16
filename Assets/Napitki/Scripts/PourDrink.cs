using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PourDrink : MonoBehaviour
{
    [SerializeField] private GameObject automat;
    [SerializeField] private GameObject triggerZone;
    [SerializeField] private GameObject stream;

    public void fillCup()
    {
        StartCoroutine(PourCoroutine());
    }

    private IEnumerator PourCoroutine()
    {
        var automatID = automat.GetComponent<Automat>().getId();
        if (
            triggerZone.GetComponent<CupToBottling>().isCupInZone()
            && !triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<Cup>().getCoverObject().activeSelf
            && !triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<Cup>().getColaObject().activeSelf
            && !triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<Cup>().getSpriteObject().activeSelf
            && !triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<Cup>().getFantaObject().activeSelf
        ){
            triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<XRGrabInteractable>().enabled = false;
            Debug.Log("Налилось");
            stream.SetActive(true);
            yield return new WaitForSeconds(4f);
            stream.SetActive(false);
            switch(automatID){
                case "cola":
                    triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<Cup>().getColaObject().SetActive(true);
                    break;
                case "sprite":
                    triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<Cup>().getSpriteObject().SetActive(true);
                    break;
                case "fanta":
                    triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<Cup>().getFantaObject().SetActive(true);
                    break;
            }
            ;
            triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<XRGrabInteractable>().enabled = true;
        }else{Debug.Log("Не налилось");}
        
    }
}
