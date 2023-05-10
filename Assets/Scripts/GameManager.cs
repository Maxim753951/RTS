using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class GameManager : MonoBehaviour
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



// фактически вызвать конвейер загрузки данных

// В конечном счете, этот сценарий позаботится об общем управлении состоянием игры в очень глобальном масштабе

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DataHandler.LoadGameData();
    }
}