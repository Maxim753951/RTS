using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Чтобы использовать эту систему событий, вы должны создать сценарии, подобные этим (этому), а затем поместить их на объект в вашей 3D-сцене
// ПРОСТО ПРИМЕР, НИКУДА ДОБАВЛЯТЬ И ИСПОЛЬБЗОВАТЬ НЕ НАДО


public class TestEmitter : MonoBehaviour
{

    private void Start()
    {
        EventManager.TriggerEvent("Test");
    }

}