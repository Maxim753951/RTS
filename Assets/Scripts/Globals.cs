using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Globals : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/



// ������ �� ����� ������� ��������� ��������� ���������� �� ������� ���������� ������ � �������.
// C������ �� ������ ��������� �� �������, �� � �������� ����� ��� ������� ��������� ��� ������ �� ����� ����� ����������� ����� ������

public class Globals
{
    public static int TERRAIN_LAYER_MASK = 1 << 8;


    public static BuildingData[] BUILDING_DATA = new BuildingData[]
    {
        new BuildingData("Building", 100)
    };

    // �� ���������� ��� "�����������" ����� ������.
    // ��� �� ������ ���������� � ����� ������ C#, ������ ��� �� ���������� ������� ��� ���������, ����� ����� ��� ������ ��������� ������;
    // � ���� � ����, ��� �� �� ����� �������� ������������ ��� ������ �� ������, � ������ ����� ��������� �� � ���� �������� ���������� ������
    // ��� ���������� �������������� ������ ������� - Building

}