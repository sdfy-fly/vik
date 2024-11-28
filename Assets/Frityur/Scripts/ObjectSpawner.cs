using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn; // Префаб объекта
    [SerializeField] private Transform handTransform;  // Трансформ руки (или позиции для спавна)

    [System.Obsolete]
    private void Awake()
    {
        if (GetComponent<XRBaseInteractable>() is XRBaseInteractable interactable)
        {
            interactable.selectEntered.AddListener(OnSelectEnter);
        }
    }

    [System.Obsolete]
    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        if (handTransform == null)
        {
            Debug.LogWarning("Hand Transform is not assigned!");
            return;
        }

        if (args.interactorObject is XRBaseInteractor interactor)
        {
            // Спавним объект
            GameObject spawnedObject = Instantiate(objectToSpawn, handTransform.position, handTransform.rotation);

            // Проверяем наличие XRGrabInteractable
            XRGrabInteractable grabInteractable = spawnedObject.GetComponent<XRGrabInteractable>();
            if (grabInteractable == null)
            {
                Debug.LogError("Spawned object is missing XRGrabInteractable component!");
                return;
            }

            // Передаём объект в управление Interaction Manager
            interactor.interactionManager.SelectEnter(interactor, grabInteractable);
        }

    }

    [System.Obsolete]
    private void OnDestroy()
    {
        if (GetComponent<XRBaseInteractable>() is XRBaseInteractable interactable)
        {
            interactable.selectEntered.RemoveListener(OnSelectEnter);
        }
    }
}
