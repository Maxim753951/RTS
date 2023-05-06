using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class GameResource : MonoBehaviour
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



// ���� ������ (�����) ��� ������������� �������������� �������.
// ��� � ��� BuildingData �����, ��� ������ ������������������� ��������� C #, ������� �������� ������, ������� ��� ������������� � ������� MonoBehaviour ������������ Unity

public class GameResource
{
    private string _name;
    private int _currentAmount;

    public GameResource(string name, int initialAmount)
    {
        _name = name;
        _currentAmount = initialAmount;
    }

    public void AddAmount(int value)
    {
        _currentAmount += value;
        if (_currentAmount < 0) _currentAmount = 0;
    }

    public string Name { get => _name; }
    public int Amount { get => _currentAmount; }
}


