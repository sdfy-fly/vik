using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverToCup : MonoBehaviour
{
    public GameObject cover;  // ������ ������
    public GameObject cup;    // ������ �������
    public Transform snapPoint;  // ����� �������� ��� ������
    public Quaternion desiredRotation;  // �������� �������� ������

    private void OnTriggerEnter(Collider colider)
    {
        // ���������, ��� ������������ � �������� � ����� "Cover"
        if (!colider.gameObject.CompareTag("Cover")) return;

        // �������� ������� ������� ����� �������
        Vector3 cupTop = cup.transform.position + cup.transform.up * (cup.GetComponent<Renderer>().bounds.size.y / 2);

        // ���������� ������ �� ������� ����� �������, �������� ������ ���������
        colider.transform.position = cupTop;

        // �������� �������� ������ ���, ����� ��� ������� � ��������� �������
        colider.transform.rotation = cup.transform.rotation;

        // ������ ������ �������� ��������� �������, ����� ��� ��������� ������ (���� ��� ����������)
        //colider.transform.SetParent(cup.transform);
        colider.transform.parent = snapPoint;

        // ��������� ���������� � Rigidbody ������
        Rigidbody coverRigidbody = colider.GetComponent<Rigidbody>();
        if (coverRigidbody != null)
        {
            coverRigidbody.useGravity = false;  // ��������� ����������
            coverRigidbody.isKinematic = true;  // ������ ������ �������������� (�� ����������� ������)
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ������ ��� ������, ���� �����
    }
}
