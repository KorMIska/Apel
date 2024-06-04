using UnityEngine;

public class PrefabChecker : MonoBehaviour
{
    void Start()
    {
        // �������� ��������� �������
        Debug.Log($"������ {gameObject.name} ������� �� ������� {transform.position}");

        // �������� ������� ����������� �����������
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log($"������ {gameObject.name} ����� Rigidbody.");
        }
        else
        {
            Debug.LogError($"������ {gameObject.name} �� ����� Rigidbody!");
        }

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            Debug.Log($"������ {gameObject.name} ����� MeshRenderer.");
        }
        else
        {
            Debug.LogError($"������ {gameObject.name} �� ����� MeshRenderer!");
        }

        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            Debug.Log($"������ {gameObject.name} ����� Collider.");
        }
        else
        {
            Debug.LogError($"������ {gameObject.name} �� ����� Collider!");
        }

        // �������� ���� �������
        Debug.Log($"������ {gameObject.name} ��������� � ���� {LayerMask.LayerToName(gameObject.layer)}");

        // �������������� �������� ����� �������� ��� �������������
    }

    void Update()
    {
        // �������� ��������� �������
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null && renderer.isVisible)
        {
            Debug.Log($"������ {gameObject.name} �����.");
        }
        else
        {
            Debug.LogWarning($"������ {gameObject.name} �� �����!");
        }
    }
}
