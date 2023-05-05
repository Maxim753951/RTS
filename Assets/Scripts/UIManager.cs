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



// Ётот класс будет отвечать за обработку всех действий, св€занных с пользовательским интерфейсом: создание кнопок, обновление текста метки, получение значени€ из входных данныхЕ
// он получает или отправл€ет данные остальным скриптам, но на самом деле он предназначен не дл€ изменени€ состо€ни€ игры, а только состо€ни€ интерфейса, но
// Ќо поскольку он €вл€етс€ глобальным дл€ всех пользовательских интерфейсов в сцене, имеет смысл добавить его к нашему игровому объекту "GAME"

public class UIManager : MonoBehaviour
{
    private BuildingPlacer _buildingPlacer;

    public Transform buildingMenu;
    public GameObject buildingButtonPrefab;

    private void Awake()
    {
        _buildingPlacer = GetComponent<BuildingPlacer>();

        // create buttons for each building type
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
        }
    }

    // € извлек это из цикла - интересна€ ошибка обратных вызовов в циклах, св€занных с пон€тием области видимости переменных.
    //  огда вы используете i в функции обратного вызова кнопки, вы фиксируете не еЄ конкретное значение на этой итерации цикла, а ссылку на неЄ,
    // котора€ будет посто€нно обновл€тьс€ по мере продолжени€ цикла.
    
    //  огда вы извлекаете определение обратного вызова, вы создаете другую функцию с ее собственной областью видимости;
    // и в этой области i действительно имеет значение, которое, по вашему мнению, она имеет на этой итерации цикла
    private void _AddBuildingButtonListener(Button b, int i)
    {
        b.onClick.AddListener(() => _buildingPlacer.SelectPlacedBuilding(i));
    }
}