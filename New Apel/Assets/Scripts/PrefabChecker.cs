using UnityEngine;

public class PrefabChecker : MonoBehaviour
{
    void Start()
    {
        // Проверка положения объекта
        Debug.Log($"Объект {gameObject.name} спавнен на позиции {transform.position}");

        // Проверка наличия необходимых компонентов
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log($"Объект {gameObject.name} имеет Rigidbody.");
        }
        else
        {
            Debug.LogError($"Объект {gameObject.name} не имеет Rigidbody!");
        }

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            Debug.Log($"Объект {gameObject.name} имеет MeshRenderer.");
        }
        else
        {
            Debug.LogError($"Объект {gameObject.name} не имеет MeshRenderer!");
        }

        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            Debug.Log($"Объект {gameObject.name} имеет Collider.");
        }
        else
        {
            Debug.LogError($"Объект {gameObject.name} не имеет Collider!");
        }

        // Проверка слоя объекта
        Debug.Log($"Объект {gameObject.name} находится в слое {LayerMask.LayerToName(gameObject.layer)}");

        // Дополнительные проверки можно добавить при необходимости
    }

    void Update()
    {
        // Проверка видимости объекта
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null && renderer.isVisible)
        {
            Debug.Log($"Объект {gameObject.name} видим.");
        }
        else
        {
            Debug.LogWarning($"Объект {gameObject.name} не видим!");
        }
    }
}
