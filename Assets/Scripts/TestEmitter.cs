using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ����� ������������ ��� ������� �������, �� ������ ������� ��������, �������� ���� (�����), � ����� ��������� �� �� ������ � ����� 3D-�����
// ������ ������, ������ ��������� � ������������� �� ����


public class TestEmitter : MonoBehaviour
{

    private void Start()
    {
        EventManager.TriggerEvent("Test");
    }

}