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

    public BuildingData(string code, int healthpoints)
    {
        _code = code;
        _healthpoints = healthpoints;
    }

    public string Code { get => _code; }
    public int HP { get => _healthpoints; }
}