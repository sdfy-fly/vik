using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverToCup : MonoBehaviour
{
    public GameObject cover;  // Объект крышки
    public GameObject cup;    // Объект стакана
    public Transform snapPoint;  // Точка привязки для крышки
    public Quaternion desiredRotation;  // Желаемое вращение крышки

    private void OnTriggerEnter(Collider colider)
    {
        // Проверяем, что столкновение с объектом с тегом "Cover"
        if (!colider.gameObject.CompareTag("Cover")) return;

        // Получаем позицию верхней части стакана
        Vector3 cupTop = cup.transform.position + cup.transform.up * (cup.GetComponent<Renderer>().bounds.size.y / 2);

        // Перемещаем крышку на верхнюю часть стакана, учитывая точное положение
        colider.transform.position = cupTop;

        // Настроим вращение крышки так, чтобы оно совпало с вращением стакана
        colider.transform.rotation = cup.transform.rotation;

        // Делаем крышку дочерним элементом стакана, чтобы они двигались вместе (если это необходимо)
        //colider.transform.SetParent(cup.transform);
        colider.transform.parent = snapPoint;

        // Отключаем гравитацию у Rigidbody крышки
        Rigidbody coverRigidbody = colider.GetComponent<Rigidbody>();
        if (coverRigidbody != null)
        {
            coverRigidbody.useGravity = false;  // Отключаем гравитацию
            coverRigidbody.isKinematic = true;  // Делаем объект кинематическим (не подчиняется физике)
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Логика для выхода, если нужно
    }
}
