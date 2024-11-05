using Unity.VisualScripting;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject potato; // Объект картошки из иерархии
    private Box box; // Ссылка на компонент Box
    private void Start()
    {
        // Получаем компонент Box, который находится на том же объекте
        box = GetComponent<Box>();
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, если триггерная зона была активирована и коробка открыта
        if (other.CompareTag("TriggerZoneForBoxFree") && box.CompareTag("BoxFree"))
        {
            if (box != null && // Есть ли коробка
                box.hasOpened && // Открыты ли крышки коробки
                potato.active == true && // Не скрыта ли картошка уже
                GameObject.FindWithTag("BunkerFree").transform.Find("Дверца бункера.001").GetComponent<DoorController>().isOpen) // Открыта ли дверца бункера
            {
                potato.SetActive(false); // Скрываем картошку
                
                GameObject.FindWithTag("BunkerFree").GetComponent<Bunker>().AddPotato(1);
                Debug.Log("картошка скрыта");
            }
            else{
                Debug.Log("картошка не скрыта");
            }
        }

        if (other.CompareTag("TriggerZoneForBoxDer") && box.CompareTag("BoxDer")){
            if (box != null && box.hasOpened && potato.active == true) // Проверяем, открыта ли коробка
            {
                potato.SetActive(false); // Скрываем картошку
                GameObject.FindWithTag("BunkerDer").GetComponent<Bunker>().AddPotato(1);
                Debug.Log("картошка скрыта");
            }
            else{
                Debug.Log("картошка не скрыта");
            }
        }
    }
}
