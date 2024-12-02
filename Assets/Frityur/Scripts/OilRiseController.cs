using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OilRiseController : MonoBehaviour
{
    public Transform oilObject; // Объект масла, который будет подниматься
    public float targetHeight = 1.0f; // Конечная высота, на которую должно подняться масло
    public float riseSpeed = 0.5f; // Скорость подъема масла

    private Vector3 initialPosition; // Начальная позиция масла
    private bool isRising = false; // Флаг для отслеживания подъема
    public bool isActive = false;

    private void Start()
    {
        // Запоминаем начальную позицию масла
        if (oilObject != null)
        {
            initialPosition = oilObject.position;
        }
    }

    // Метод, который вызывается при наведении на кнопку
    public void StartOilRise()
    {
        if (oilObject != null)
        {
            isRising = true;
        }
    }

    private void Update()
    {
        // Если масло должно подниматься
        if (isRising && oilObject != null)
        {
            // Поднимаем объект масла плавно по оси Y
            Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y + targetHeight, initialPosition.z);
            oilObject.position = Vector3.MoveTowards(oilObject.position, targetPosition, riseSpeed * Time.deltaTime);

            // Останавливаем подъем, когда достигается цель
            if (oilObject.position == targetPosition)
            {
                isRising = false;
                isActive = true;
            }
        }
    }
}
