using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/*
public class UIManager : MonoBehaviour
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



// ���� ����� ����� �������� �� ��������� ���� ��������, ��������� � ���������������� �����������: �������� ������, ���������� ������ �����, ��������� �������� �� ������� �������
// �� �������� ��� ���������� ������ ��������� ��������, �� �� ����� ���� �� ������������ �� ��� ��������� ��������� ����, � ������ ��������� ����������, ��
// �� ��������� �� �������� ���������� ��� ���� ���������������� ����������� � �����, ����� ����� �������� ��� � ������ �������� ������� "GAME"

public class UIManager : MonoBehaviour
{
    private BuildingPlacer _buildingPlacer;


    public Transform buildingMenu;
    public GameObject buildingButtonPrefab;


    public Transform resourcesUIParent;
    public GameObject gameResourceDisplayPrefab;

    private Dictionary<string, Text> _resourceTexts;


    private Dictionary<string, Button> _buildingButtons;


    // � ����� �� ������ ��������� ��������������� �������������� � UIManager ����� -
    // ��� ������� ����������� �������� ��������� ������� ��������� ������ (associated callback functions) �� ������� ������ (private methods),
    // ����� �������� ���� ������������ ������, � �������� � ���� �������� ������� ������� "On" (��� ������� ���������� ��� ����������� �������� ������� �������)

    private void OnEnable()
    {
        EventManager.AddListener("UpdateResourceTexts", _OnUpdateResourceTexts);
        EventManager.AddListener("CheckBuildingButtons", _OnCheckBuildingButtons);
    }

    private void OnDisable()
    {
        EventManager.RemoveListener("UpdateResourceTexts", _OnUpdateResourceTexts);
        EventManager.RemoveListener("CheckBuildingButtons", _OnCheckBuildingButtons);
    }


    private void Awake()
    {
        // create texts for each in-game resource (gold, wood, stone...)
        _resourceTexts = new Dictionary<string, Text>();
        foreach (KeyValuePair<string, GameResource> pair in Globals.GAME_RESOURCES)
        {
            GameObject display = Instantiate(gameResourceDisplayPrefab, resourcesUIParent);
            display.name = pair.Key;
            _resourceTexts[pair.Key] = display.transform.Find("Text").GetComponent<Text>();
            _SetResourceText(pair.Key, pair.Value.Amount);
        }


        _buildingPlacer = GetComponent<BuildingPlacer>();

        // create buttons for each building type
        _buildingButtons = new Dictionary<string, Button>();
        for (int i = 0; i < Globals.BUILDING_DATA.Length; i++)
        {
            BuildingData data = Globals.BUILDING_DATA[i];
            GameObject button = Instantiate(buildingButtonPrefab, buildingMenu);
            button.name = data.unitName;
            button.transform.Find("Text").GetComponent<Text>().text = data.unitName;
            //_buildingButtons[data.code] = b;


            /*
            GameObject button = GameObject.Instantiate(
                buildingButtonPrefab,
                buildingMenu);
            */
            //string code = Globals.BUILDING_DATA[i].Code;
            //button.name = code;
            //button.transform.Find("Text").GetComponent<Text>().text = code;
            Button b = button.GetComponent<Button>();
            _AddBuildingButtonListener(b, i);


            //_buildingButtons[code] = b;


            _buildingButtons[data.code] = b;


            if (!Globals.BUILDING_DATA[i].CanBuy())
            {
                b.interactable = false;
            }
        }
    }

    // � ������ ��� �� ����� - ���������� ������ �������� ������� � ������, ��������� � �������� ������� ��������� ����������.
    // ����� �� ����������� i � ������� ��������� ������ ������, �� ���������� �� � ���������� �������� �� ���� �������� �����, � ������ �� ��,
    // ������� ����� ��������� ����������� �� ���� ����������� �����.
    
    // ����� �� ���������� ����������� ��������� ������, �� �������� ������ ������� � �� ����������� �������� ���������;
    // � � ���� ������� i ������������� ����� ��������, �������, �� ������ ������, ��� ����� �� ���� �������� �����
    private void _AddBuildingButtonListener(Button b, int i)
    {
        b.onClick.AddListener(() => _buildingPlacer.SelectPlacedBuilding(i));
    }


    // �� ����� ����������� ���� GAME_RESOURCES � ������� ��������� ���������� ����������� �������� ��� �������

    private void _SetResourceText(string resource, int value)
    {
        _resourceTexts[resource].text = value.ToString();
    }

    /*
    public void UpdateResourceTexts()
    {
        foreach (KeyValuePair<string, GameResource> pair in Globals.GAME_RESOURCES)
        {
            _SetResourceText(pair.Key, pair.Value.Amount);
        }
    }


    public void CheckBuildingButtons()
    {
        foreach (BuildingData data in Globals.BUILDING_DATA)
        {
            _buildingButtons[data.Code].interactable = data.CanBuy();
        }
    }
    */


    private void _OnUpdateResourceTexts()
    {
        foreach (KeyValuePair<string, GameResource> pair in Globals.GAME_RESOURCES)
            _SetResourceText(pair.Key, pair.Value.Amount);
    }

    private void _OnCheckBuildingButtons()
    {
        foreach (BuildingData data in Globals.BUILDING_DATA)
            _buildingButtons[data.code].interactable = data.CanBuy();
    }
}