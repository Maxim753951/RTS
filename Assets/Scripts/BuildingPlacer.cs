using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
public class BuildingPlacer : MonoBehaviour
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



// "фантомная" визуализация здания
// Этот "фантом" следует за вашей мышью, приклеивая здание, которое скоро будет размещено, к земле.

// Для этого мы будем использовать физическую систему raycast от Unity:
// это позволяет нам направлять луч с камеры на землю в зависимости от положения нашей мыши;
// и, следовательно, получать точную точку в трехмерном мире на земле, на которую указывает наша мышь.

// Поскольку это не соответствует какому-либо конкретному игровому объекту, но несколько глобально для сцены, мы будем добавлять его на пустой объект сцены - GAME
// Этот пустой объект содержит скрипты, которые являются глобальными менеджерами состояния игры

public class BuildingPlacer : MonoBehaviour
{
    private Building _placedBuilding = null;


    private Ray _ray;
    private RaycastHit _raycastHit;
    private Vector3 _lastPlacementPosition;


    /* (we remove the Start() method)
    void Start()
    {
        // for now, we'll automatically pick our first
        // building type as the type we want to build
        _PreparePlacedBuilding(0);
    }
    */


    void Update()
    {

        if (_placedBuilding != null)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                _CancelPlacedBuilding();
                return;
            }


            // ... do the raycast
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(
                _ray,
                out _raycastHit,
                1000f,
                Globals.TERRAIN_LAYER_MASK
            ))
            {
                _placedBuilding.SetPosition(_raycastHit.point);
                if (_lastPlacementPosition != _raycastHit.point)
                {
                    _placedBuilding.CheckValidPlacement();
                }
                _lastPlacementPosition = _raycastHit.point;
            }


            // EventSystems пакет Unity, который заботится о взаимодействии с элементами пользовательского интерфейса.
            // Мы просто проверим, что в данный момент у нас нет события для элемента пользовательского интерфейса, подобного этому

            if (
                _placedBuilding.HasValidPlacement &&
                Input.GetMouseButtonDown(0) &&
                !EventSystem.current.IsPointerOverGameObject()
            )
            {
                _PlaceBuilding();
            }
        }
    }

    void _PreparePlacedBuilding(int buildingDataIndex)
    {
        
        // -----------------------------------------------------------
        // destroy the previous "phantom" if there is one
        if (_placedBuilding != null && !_placedBuilding.IsFixed)
            Destroy(_placedBuilding.Transform.gameObject);
        // -----------------------------------------------------------
        

    // Нам нужно вызвать нашу Initialize() функцию при выборе типа здания, чтобы вновь созданный Building экземпляр мог связать свои данные со своим BuildingManager скриптом
    // (который мы поместили в Префаб "Building", чтобы он автоматически присутствовал в каждом новом экземпляре Префаба здания)
    Building building = new Building(
            Globals.BUILDING_DATA[buildingDataIndex]
        );
        // link the data into the manager
        building.Transform.GetComponent<BuildingManager>().Initialize(building);
        _placedBuilding = building;
        _lastPlacementPosition = Vector3.zero;
    }


    void _PlaceBuilding()
    {
        _placedBuilding.Place();
        // keep on building the same building type
        _PreparePlacedBuilding(_placedBuilding.DataIndex);
    }


    void _CancelPlacedBuilding()
    {
        // destroy the "phantom" building
        Destroy(_placedBuilding.Transform.gameObject);
        _placedBuilding = null;
    }


    public void SelectPlacedBuilding(int buildingDataIndex)
    {
        _PreparePlacedBuilding(buildingDataIndex);
    }
}