using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class BuildingData : MonoBehaviour
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



// Первое, что мы хотим сделать, это получить список всех доступных типов зданий.

// Итак, давайте определим класс для представления некоторых абстрактных данных о здании (тип здания).
// Ему не нужно наследовать от MonoBehaviour класса, потому что он просто содержит некоторые данные

public class BuildingData
{
    private string _code;
    private int _healthpoints;


    private Dictionary<string, int> _cost;


    public BuildingData(string code, int healthpoints, Dictionary<string, int> cost)
    {
        _code = code;
        _healthpoints = healthpoints;
        _cost = cost;
    }


    public bool CanBuy()
    {
        foreach (KeyValuePair<string, int> pair in _cost)
        {
            if (Globals.GAME_RESOURCES[pair.Key].Amount < pair.Value)
            {
                return false;
            }
        }
        return true;
    }


    public string Code { get => _code; }
    public int HP { get => _healthpoints; }


    public Dictionary<string, int> Cost { get => _cost; }
}