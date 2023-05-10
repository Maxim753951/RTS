using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class DataHandler : MonoBehaviour
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



// ����������� ����� ��� ���������� ��������� � ����������� ���� ������
// �� ���� ����� ��� ����� ������ ��������� ���� ������

public static class DataHandler
{
    public static void LoadGameData()
    {
        Globals.BUILDING_DATA = Resources.LoadAll<BuildingData>("ScriptableObjects/Units/Buildings") as BuildingData[];
    }
}