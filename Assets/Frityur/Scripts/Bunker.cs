using UnityEngine;

public class Bunker : MonoBehaviour
{
    public int potatoCount = 0; // Количество картошки в бункере

    // Метод для добавления картошки
    public void AddPotato(int amount)
    {
        potatoCount += amount;
        Debug.Log($"Добавлено {amount} картошек в бункер. Текущее количество: {potatoCount}");
    }
}
