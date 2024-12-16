using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AddIce : MonoBehaviour
{
    [SerializeField] private GameObject automat; // Возможно, используется для ориентации
    [SerializeField] private GameObject icePrefab;
    [SerializeField] private GameObject triggerZone;

    public void addIce()
    {
        StartCoroutine(IceCoroutine());
    }

    private IEnumerator IceCoroutine()
    {
        if(
            triggerZone.GetComponent<CupToBottling>().isCupInZone()
            && !triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<Cup>().getCoverObject().activeSelf
            && !triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<Cup>().getIceObject().activeSelf
            && (triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<Cup>().getColaObject().activeSelf
                || triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<Cup>().getSpriteObject().activeSelf
                || triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<Cup>().getFantaObject().activeSelf)
        ){
            triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<XRGrabInteractable>().enabled = false;
            GameObject newIce = Instantiate(icePrefab, icePrefab.transform.position, icePrefab.transform.rotation);

            Vector3 startPosition = newIce.transform.position;
            Vector3 endPosition = startPosition + Vector3.down * 0.1f;

            float duration = 1f;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                newIce.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            newIce.transform.position = endPosition;

            Destroy(newIce);
            triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<Cup>().getIceObject().SetActive(true);
            triggerZone.GetComponent<CupToBottling>().getCup().GetComponent<XRGrabInteractable>().enabled = true;
        }
    }
}
