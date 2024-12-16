using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupToCloset : MonoBehaviour
{
    [SerializeField] private string place;
    [SerializeField] private List<GameObject> snapPoints;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Cup")){
            if( other.gameObject.GetComponent<Cup>().getColaObject().activeSelf
                && other.gameObject.GetComponent<Cup>().getCoverObject().activeSelf
                && other.gameObject.GetComponent<Cup>().getIceObject().activeSelf 
                && place == "Кола со льдом"
            ){
                AttachToSnapPoint(other.gameObject);
            }
            
            if( other.gameObject.GetComponent<Cup>().getColaObject().activeSelf
                && other.gameObject.GetComponent<Cup>().getCoverObject().activeSelf 
                && !other.gameObject.GetComponent<Cup>().getIceObject().activeSelf 
                && place == "Кола безо льда"
            ){
                AttachToSnapPoint(other.gameObject);
            } 
            
            if( other.gameObject.GetComponent<Cup>().getFantaObject().activeSelf 
                && other.gameObject.GetComponent<Cup>().getCoverObject().activeSelf
                && other.gameObject.GetComponent<Cup>().getIceObject().activeSelf 
                && place == "Фанта со льдом"
            ){
                AttachToSnapPoint(other.gameObject);
            } 
            
            if( other.gameObject.GetComponent<Cup>().getFantaObject().activeSelf 
                && other.gameObject.GetComponent<Cup>().getCoverObject().activeSelf
                && !other.gameObject.GetComponent<Cup>().getIceObject().activeSelf 
                && place == "Фанта безо льда"
            ){
                AttachToSnapPoint(other.gameObject);
            }
            
            if( other.gameObject.GetComponent<Cup>().getSpriteObject().activeSelf 
                && other.gameObject.GetComponent<Cup>().getCoverObject().activeSelf
                && other.gameObject.GetComponent<Cup>().getIceObject().activeSelf 
                && place == "Спрайт со льдом"
            ){
                AttachToSnapPoint(other.gameObject);
            }

            if( other.gameObject.GetComponent<Cup>().getSpriteObject().activeSelf 
                && other.gameObject.GetComponent<Cup>().getCoverObject().activeSelf
                && !other.gameObject.GetComponent<Cup>().getIceObject().activeSelf 
                && place == "Спрайт безо льда"
            ){
                AttachToSnapPoint(other.gameObject);
            }
            
        }
    }

     private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cup"))
        {
            foreach (var snapPoint in snapPoints)
            {
                SnapPoint snapPointScript = snapPoint.GetComponent<SnapPoint>();

                // Освобождаем точку, если объект покинул ее
                if (snapPointScript.GetOccupyingObject() == other.gameObject)
                {
                    snapPointScript.SetIsOccupied(false, other.gameObject);
                    Debug.Log($"Объект {other.name} покинул {snapPoint.name}");
                    return;
                }
            }
        }
    }

    private void AttachToSnapPoint(GameObject cup)
    {
        foreach (var snapPoint in snapPoints)
        {
            // Проверяем, занята ли точка
            if (!snapPoint.GetComponent<SnapPoint>().GetIsOccupied())
            {
                // Устанавливаем позицию объекта на точку привязки
                cup.transform.position = snapPoint.transform.position;
                cup.transform.rotation = snapPoint.transform.rotation;

                // Отмечаем точку как занятую
                snapPoint.GetComponent<SnapPoint>().SetIsOccupied(true, cup);

                Debug.Log($"Объект {cup.name} привязан к {snapPoint.name}");
                return;
            }
        }

        // Если свободной точки не нашлось
        Debug.Log("Нет свободных точек для привязки.");
    }

    public List<GameObject> getSnapPoints(){
        return snapPoints;
    }
}
