using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class FillTray : MonoBehaviour
{
    [SerializeField] private Transform snapPointBurger;
    [SerializeField] private Transform snapPointPotato;
    [SerializeField] private Transform snapPointDrink;
    [SerializeField] private Transform snapPointTube;
    [SerializeField] private Transform snapPointSauce;
    [SerializeField] private Transform snapPointNapkin;
    public List<string> food;
 
    private void OnTriggerEnter(Collider other) {
        if ((other.CompareTag("Starter") || other.CompareTag("BigSpecial") || other.CompareTag("BigMack") || other.CompareTag("Roll")) && !snapPointBurger.GetComponent<SnapPoint>().GetIsOccupied()) {
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
            if(other.CompareTag("Starter")){food.Add("стартер");}
            if(other.CompareTag("BigSpecial")){food.Add("биг спешиал");}
            if(other.CompareTag("BigMack")){food.Add("биг мак");}
            if(other.CompareTag("Roll")){food.Add("ролл");}
            Debug.Log("Текущий список food: " + string.Join(", ", food));
        }

        if ((other.CompareTag("SmallFree") || other.CompareTag("AverageFree") || other.CompareTag("LargeFree") || other.CompareTag("AverageDer") || other.CompareTag("LargeDer") || other.CompareTag("Naggets")) && !snapPointPotato.GetComponent<SnapPoint>().GetIsOccupied()) {
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
            if(other.CompareTag("SmallFree")){food.Add("мал фри");}
            if(other.CompareTag("AverageFree")){food.Add("ср фри");}
            if(other.CompareTag("LargeFree")){food.Add("бол фри");}
            if(other.CompareTag("AverageDer")){food.Add("бол дер");}
            if(other.CompareTag("LargeDer")){food.Add("бол дер");}
            if(other.CompareTag("Naggets")){food.Add("наггетсы");}
            Debug.Log("Текущий список food: " + string.Join(", ", food));
        }

        if ((other.CompareTag("Cola") || other.CompareTag("Fanta") || other.CompareTag("Sprite") || other.CompareTag("ColaIce") || other.CompareTag("FantaIce") || other.CompareTag("SpriteIce")) && !snapPointDrink.GetComponent<SnapPoint>().GetIsOccupied()) {
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
            if(other.CompareTag("Cola")){food.Add("кола");}
            if(other.CompareTag("Fanta")){food.Add("фанта");}
            if(other.CompareTag("Sprite")){food.Add("спрайт");}
            if(other.CompareTag("ColaIce")){food.Add("кола лёд");}
            if(other.CompareTag("FantaIce")){food.Add("фанта лёд");}
            if(other.CompareTag("SpriteIce")){food.Add("спрайт лёд");}
            Debug.Log("Текущий список food: " + string.Join(", ", food));
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
            other.transform.rotation = Quaternion.Euler(-90, 0, 0);  // Поворот на 90 градусов по оси Y
            other.transform.SetParent(this.transform);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = true;

            // Отмечаем точку как занятую
            snapPointTube.GetComponent<SnapPoint>().SetIsOccupied(true, other.gameObject);
            food.Add("трубочка");
            Debug.Log("Текущий список food: " + string.Join(", ", food));
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
            food.Add("соус");
            Debug.Log("Текущий список food: " + string.Join(", ", food));
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
            food.Add("салфетка");
            Debug.Log("Текущий список food: " + string.Join(", ", food));
        }
    }
}
