using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Чтобы использовать эту систему событий, вы должны создать сценарии, подобные этим (этому), а затем поместить их на объект в вашей 3D-сцене
// ПРОСТО ПРИМЕР, НИКУДА ДОБАВЛЯТЬ И ИСПОЛЬБЗОВАТЬ НЕ НАДО


public class TestListener : MonoBehaviour
{

    private void OnEnable()
    {
        EventManager.AddListener("Test", _OnTest);
    }

    private void OnDisable()
    {
        EventManager.RemoveListener("Test", _OnTest);
    }

    private void _OnTest()
    {
        Debug.Log("Received the'Test' event!");
    }

}