using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishOrderSborka : MonoBehaviour
{
    [SerializeField] private GameObject table;
    [SerializeField] private List<string> order;

    public void CompleteOrder(){
        GameObject tray = table.GetComponent<SnapPoint>().GetOccupyingObject();
        if(tray != null){
            List<string> food = tray.GetComponent<FillTray>().food;
            if (food != null) {
                Debug.Log("Текущий список food: " + string.Join(", ", food));
                
                // Сравниваем списки
                if (AreListsEqual(order, food)) {
                    Debug.Log("Заказ выполнен!");
                    this.gameObject.SetActive(false);
                    Destroy(tray);
                } else {
                    Debug.Log("Еда в заказе и на подносе не совпадает!");
                }
            }
        }
    }

    private bool AreListsEqual(List<string> list1, List<string> list2) {
        // Если размеры списков разные, то они точно разные
        if (list1.Count != list2.Count) return false;

        // Сортируем оба списка
        list1.Sort();
        list2.Sort();

        // Сравниваем элементы по порядку
        for (int i = 0; i < list1.Count; i++) {
            if (list1[i] != list2[i]) return false;
        }

        return true;
    }
}
