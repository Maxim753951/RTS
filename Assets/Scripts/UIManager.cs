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



// Этот класс будет отвечать за обработку всех действий, связанных с пользовательским интерфейсом: создание кнопок, обновление текста метки, получение значения из входных данных…
// он получает или отправляет данные остальным скриптам, но на самом деле он предназначен не для изменения состояния игры, а только состояния интерфейса, но
// Но поскольку он является глобальным для всех пользовательских интерфейсов в сцене, имеет смысл добавить его к нашему игровому объекту "GAME"

public class UIManager : MonoBehaviour
{
    private BuildingPlacer _buildingPlacer;


    public Transform buildingMenu;
    public GameObject buildingButtonPrefab;


    public Transform resourcesUIParent;
    public GameObject gameResourceDisplayPrefab;

    private Dictionary<string, Text> _resourceTexts;


    private Dictionary<string, Button> _buildingButtons;


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
            GameObject button = GameObject.Instantiate(
                buildingButtonPrefab,
                buildingMenu);
            string code = Globals.BUILDING_DATA[i].Code;
            button.name = code;
            button.transform.Find("Text").GetComponent<Text>().text = code;
            Button b = button.GetComponent<Button>();
            _AddBuildingButtonListener(b, i);


            _buildingButtons[code] = b;
            if (!Globals.BUILDING_DATA[i].CanBuy())
            {
                b.interactable = false;
            }
        }
    }

    // я извлек это из цикла - интересная ошибка обратных вызовов в циклах, связанных с понятием области видимости переменных.
    // Когда вы используете i в функции обратного вызова кнопки, вы фиксируете не её конкретное значение на этой итерации цикла, а ссылку на неё,
    // которая будет постоянно обновляться по мере продолжения цикла.
    
    // Когда вы извлекаете определение обратного вызова, вы создаете другую функцию с ее собственной областью видимости;
    // и в этой области i действительно имеет значение, которое, по вашему мнению, она имеет на этой итерации цикла
    private void _AddBuildingButtonListener(Button b, int i)
    {
        b.onClick.AddListener(() => _buildingPlacer.SelectPlacedBuilding(i));
    }


    // мы можем просмотреть наши GAME_RESOURCES и создать экземпляр небольшого отображения ресурсов для каждого

    private void _SetResourceText(string resource, int value)
    {
        _resourceTexts[resource].text = value.ToString();
    }

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
}