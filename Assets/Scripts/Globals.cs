using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Globals : MonoBehaviour
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



// Теперь мы можем создать глобально доступную переменную со списком справочных данных о зданиях.
// Cегодня мы просто определим ее вручную, но в конечном итоге нам следует загрузить эти ссылки из более легко изменяемого файла данных

public class Globals
{
    public static int TERRAIN_LAYER_MASK = 1 << 8;


    public static BuildingData[] BUILDING_DATA = new BuildingData[]
    {
        new BuildingData("House", 100),
        new BuildingData("Tower", 50)
    };

    // Мы определили наш "абстрактный" класс данных.
    // Это не совсем абстрактно с точки зрения C#, потому что мы фактически создаем его экземпляр, чтобы иметь наш список доступных зданий;
    // я имею в виду, что мы не будем напрямую представлять эти данные на экране, а вместо этого передадим их в наши реальные экземпляры зданий
    // Эти экземпляры обрабатываются другим классом - Building

}