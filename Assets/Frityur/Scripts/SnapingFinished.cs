using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapingFinished : MonoBehaviour
{
    [SerializeField] private List<Transform> snapPoints; // Список точек привязки
    public List<GameObject> snapPointOccupied; // Список для отслеживания привязанных объектов

    void Start()
    {
        // Инициализация списка для отслеживания занятых точек и привязанных объектов
        snapPointOccupied = new List<GameObject>();

        // Для каждой точки привязки добавляем в список null (точка еще не занята)
        foreach (var snapPoint in snapPoints)
        {
            snapPointOccupied.Add(null);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, если объект может быть привязан (например, у него есть тег или нужная метка)
        if (other.CompareTag("LargeFree") || other.CompareTag("AverageFree") || other.CompareTag("SmallFree") || other.CompareTag("LargeDer") || other.CompareTag("AverageDer"))
        {
            // Пытаемся найти первую свободную точку привязки
            for (int i = 0; i < snapPoints.Count; i++)
            {
                if (snapPointOccupied[i] == null) // Если точка свободна
                {
                    // Привязываем объект к этой точке
                    other.transform.position = snapPoints[i].position;
                    other.transform.rotation = snapPoints[i].rotation; // Можно добавлять ориентацию, если нужно
                    snapPointOccupied[i] = other.gameObject; // Помечаем точку как занятую и сохраняем объект
                    Debug.Log($"Объект {other.name} привязан к точке {snapPoints[i].name}");
                    DisplayOccupiedSnapPoints(); // Выводим список привязанных объектов
                    break; // Прерываем цикл, так как объект привязан
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Освобождаем точку привязки, когда объект выходит из зоны
        if (other.CompareTag("LargeFree") || other.CompareTag("AverageFree") || other.CompareTag("SmallFree") || other.CompareTag("LargeDer") || other.CompareTag("AverageDer"))
        {
            // Ищем объект в списке и освобождаем точку привязки
            for (int i = 0; i < snapPoints.Count; i++)
            {
                if (snapPointOccupied[i] == other.gameObject) // Проверяем, если объект был привязан к точке
                {
                    snapPointOccupied[i] = null; // Освобождаем точку
                    Debug.Log($"Точка {snapPoints[i].name} освобождена от объекта {other.name}");
                    DisplayOccupiedSnapPoints(); // Выводим список привязанных объектов
                    break; // Прерываем цикл, так как точка освобождена
                }
            }
        }
    }

    // Метод для отображения списка привязанных объектов
    private void DisplayOccupiedSnapPoints()
    {
        Debug.Log("Текущие привязанные объекты:");
        for (int i = 0; i < snapPointOccupied.Count; i++)
        {
            if (snapPointOccupied[i] != null)
            {
                Debug.Log($"Точка {snapPoints[i].name} занята объектом {snapPointOccupied[i].name}");
            }
            else
            {
                Debug.Log($"Точка {snapPoints[i].name} не занята");
            }
        }
    }
}
