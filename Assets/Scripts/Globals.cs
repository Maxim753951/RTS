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


    // �� ���������� ��� "�����������" ����� ������.
    // ��� �� ������ ���������� � ����� ������ C#, ������ ��� �� ���������� ������� ��� ���������, ����� ����� ��� ������ ��������� ������;
    // � ���� � ����, ��� �� �� ����� �������� ������������ ��� ������ �� ������, � ������ ����� ��������� �� � ���� �������� ���������� ������
    // ��� ���������� �������������� ������ ������� - Building

    public static BuildingData[] BUILDING_DATA = new BuildingData[]
    {
        new BuildingData("House", 100, new Dictionary<string, int>()
        {
            { "gold", 100 },
            { "wood", 120 }
        }),
        new BuildingData("Tower", 100, new Dictionary<string, int>()
        {
            { "gold", 80 },
            { "wood", 80 },
            { "stone", 100 }
        }),
    };


    // ��� ��������� ������������� ���������� / ����������� ���������� �� �������� ������� �������� �����������.
    // ��� ������������� ���������� ����������, ���� � ��� ��������� ������, ��� ���������� �������� �� ������ ������� � ����� ����, ������� ������ ���������, ������ ������� ������.
    // ������� ����� �����, ��� �� ����������� ����������, ����� �� ����� ����������� ������ ������ �� ���������� �������.
    // ������ ����� ������������ �������, �������� ��������������� �������.
    // �� ��� ������� ��������, � ����� ��� �� �����������, ������ ��� �� ���������� ��� �������� �������� ���� � ����� �������, � �� ������ ���� ������� ���������������� �������� ��������.

    public static Dictionary<string, GameResource> GAME_RESOURCES =
        new Dictionary<string, GameResource>()
    {
        { "gold", new GameResource("Gold", 300) },
        { "wood", new GameResource("Wood", 300) },
        { "stone", new GameResource("Stone", 300) }
    };


    // ������ �������� ����������� ������ ��������� ������

    public static List<UnitManager> SELECTED_UNITS = new List<UnitManager>();
}