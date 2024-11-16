using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUTTON_FOR_FALL : MonoBehaviour
{
    public GameObject sphere; // ������ �� ������������ �����
    private void OnTriggerEnter(Collider other) { 
        // ���������, ��� ��������� ����������� ����� (������ �������� "Player" �� ��� ������ �����)
        if (other.CompareTag("Player2") || other.CompareTag("Player1")) 
        { 
        // ���������, ���� � ����� ��� ���� ��������� Rigidbody, �� ��������� ���, ���� ���
            if (!sphere.GetComponent<Rigidbody>()) 
            {
                Rigidbody rb = sphere.AddComponent<Rigidbody>(); 
                // ����� ��������� ��������� Rigidbody, ���� ����������
                rb.mass = 1;
                rb.drag = 1f; 
                rb.angularDrag = 0.05f; 
            } 
        }
    }
}

