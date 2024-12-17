using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FillTray : MonoBehaviour
{
    [SerializeField] private Transform snapPointBurger;
    [SerializeField] private Transform snapPointPotato;
    [SerializeField] private Transform snapPointDrink;
    [SerializeField] private Transform snapPointTube;
    [SerializeField] private Transform snapPointSauce;
    [SerializeField] private Transform snapPointNapkin;
 
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Starter") && !snapPointBurger.GetComponent<SnapPoint>().GetIsOccupied()) {
            Debug.Log("Бургер на подносе");

            // Отключаем возможность захвата объекта, отключив компонент XRGrabInteractable
            XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.enabled = false; // Отключаем взаимодействие
            }

            // Отключаем BoxCollider объекта, который вошел в триггер
            BoxCollider boxCollider = other.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = false; // Отключаем BoxCollider
            }

            // Устанавливаем объект на точку
            other.transform.position = snapPointBurger.transform.position;
            other.transform.rotation = snapPointBurger.transform.rotation;
            other.transform.SetParent(this.transform);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = true;

            // Отмечаем точку как занятую
            snapPointBurger.GetComponent<SnapPoint>().SetIsOccupied(true, other.gameObject);
        }

        if (other.CompareTag("Potato") && !snapPointPotato.GetComponent<SnapPoint>().GetIsOccupied()) {
            Debug.Log("Картошка на подносе");

            // Отключаем возможность захвата объекта, отключив компонент XRGrabInteractable
            XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.enabled = false; // Отключаем взаимодействие
            }

            // Отключаем BoxCollider объекта, который вошел в триггер
            BoxCollider boxCollider = other.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = false; // Отключаем BoxCollider
            }

            // Устанавливаем объект на точку
            other.transform.position = snapPointPotato.transform.position;
            other.transform.rotation = snapPointPotato.transform.rotation;
            other.transform.SetParent(this.transform);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = true;

            // Отмечаем точку как занятую
            snapPointPotato.GetComponent<SnapPoint>().SetIsOccupied(true, other.gameObject);
        }

        if (other.CompareTag("Drink") && !snapPointDrink.GetComponent<SnapPoint>().GetIsOccupied()) {
            Debug.Log("Напиток на подносе");

            // Отключаем возможность захвата объекта, отключив компонент XRGrabInteractable
            XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.enabled = false; // Отключаем взаимодействие
            }

            // Отключаем BoxCollider объекта, который вошел в триггер
            BoxCollider boxCollider = other.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = false; // Отключаем BoxCollider
            }

            // Устанавливаем объект на точку
            other.transform.position = snapPointDrink.transform.position;
            other.transform.rotation = snapPointDrink.transform.rotation;
            other.transform.SetParent(this.transform);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = true;

            // Отмечаем точку как занятую
            snapPointDrink.GetComponent<SnapPoint>().SetIsOccupied(true, other.gameObject);
        }

        if (other.CompareTag("Tube") && !snapPointTube.GetComponent<SnapPoint>().GetIsOccupied()) {
            Debug.Log("Трубочка на подносе");

            // Отключаем возможность захвата объекта, отключив компонент XRGrabInteractable
            XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.enabled = false; // Отключаем взаимодействие
            }

            // Отключаем BoxCollider объекта, который вошел в триггер
            BoxCollider boxCollider = other.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = false; // Отключаем BoxCollider
            }

            // Устанавливаем объект на точку
            other.transform.position = snapPointTube.transform.position;
            other.transform.rotation = Quaternion.Euler(0, 90, 0);  // Поворот на 90 градусов по оси Y
            other.transform.SetParent(this.transform);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = true;

            // Отмечаем точку как занятую
            snapPointTube.GetComponent<SnapPoint>().SetIsOccupied(true, other.gameObject);
        }

        if (other.CompareTag("Sauce") && !snapPointSauce.GetComponent<SnapPoint>().GetIsOccupied()) {
            Debug.Log("Трубочка на подносе");

            // Отключаем возможность захвата объекта, отключив компонент XRGrabInteractable
            XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.enabled = false; // Отключаем взаимодействие
            }

            // Отключаем BoxCollider объекта, который вошел в триггер
            BoxCollider boxCollider = other.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = false; // Отключаем BoxCollider
            }

            // Устанавливаем объект на точку
            other.transform.position = snapPointSauce.transform.position;
            other.transform.rotation = snapPointSauce.transform.rotation; 
            other.transform.SetParent(this.transform);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = true;

            // Отмечаем точку как занятую
            snapPointSauce.GetComponent<SnapPoint>().SetIsOccupied(true, other.gameObject);
        }

        if (other.CompareTag("Napkin") && !snapPointNapkin.GetComponent<SnapPoint>().GetIsOccupied()) {
            Debug.Log("Трубочка на подносе");

            // Отключаем возможность захвата объекта, отключив компонент XRGrabInteractable
            XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.enabled = false; // Отключаем взаимодействие
            }

            // Отключаем BoxCollider объекта, который вошел в триггер
            BoxCollider boxCollider = other.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = false; // Отключаем BoxCollider
            }

            // Устанавливаем объект на точку
            other.transform.position = snapPointNapkin.transform.position;
            other.transform.rotation = snapPointNapkin.transform.rotation; 
            other.transform.SetParent(this.transform);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = true;

            // Отмечаем точку как занятую
            snapPointNapkin.GetComponent<SnapPoint>().SetIsOccupied(true, other.gameObject);
        }
    }

    // Можно добавить методы для OnTriggerExit, если нужно освободить точки при выходе объектов из зоны
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Starter") && other.gameObject == snapPointBurger.GetComponent<SnapPoint>().GetOccupyingObject()) {
            Debug.Log("Бургер забрали с подноса");

            // Включаем BoxCollider, когда объект выходит из зоны
            BoxCollider boxCollider = other.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = true; // Включаем BoxCollider обратно
            }

            snapPointBurger.GetComponent<SnapPoint>().SetIsOccupied(false, null);
        }

        if (other.CompareTag("Potato") && other.gameObject == snapPointPotato.GetComponent<SnapPoint>().GetOccupyingObject()) {
            Debug.Log("Картошка забрали с подноса");

            // Включаем BoxCollider, когда объект выходит из зоны
            BoxCollider boxCollider = other.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = true; // Включаем BoxCollider обратно
            }

            snapPointPotato.GetComponent<SnapPoint>().SetIsOccupied(false, null);
        }
    }
}
