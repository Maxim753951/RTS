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



// "���������" ������������ ������
// ���� "������" ������� �� ����� �����, ���������� ������, ������� ����� ����� ���������, � �����.

// ��� ����� �� ����� ������������ ���������� ������� raycast �� Unity:
// ��� ��������� ��� ���������� ��� � ������ �� ����� � ����������� �� ��������� ����� ����;
// �, �������������, �������� ������ ����� � ���������� ���� �� �����, �� ������� ��������� ���� ����.

// ��������� ��� �� ������������� ������-���� ����������� �������� �������, �� ��������� ��������� ��� �����, �� ����� ��������� ��� �� ������ ������ ����� - GAME
// ���� ������ ������ �������� �������, ������� �������� ����������� ����������� ��������� ����

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


            // EventSystems ����� Unity, ������� ��������� � �������������� � ���������� ����������������� ����������.
            // �� ������ ��������, ��� � ������ ������ � ��� ��� ������� ��� �������� ����������������� ����������, ��������� �����

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
        

    // ��� ����� ������� ���� Initialize() ������� ��� ������ ���� ������, ����� ����� ��������� Building ��������� ��� ������� ���� ������ �� ����� BuildingManager ��������
    // (������� �� ��������� � ������ "Building", ����� �� ������������� ������������� � ������ ����� ���������� ������� ������)
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