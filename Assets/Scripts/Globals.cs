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


    // Мы определили наш "абстрактный" класс данных.
    // Это не совсем абстрактно с точки зрения C#, потому что мы фактически создаем его экземпляр, чтобы иметь наш список доступных зданий;
    // я имею в виду, что мы не будем напрямую представлять эти данные на экране, а вместо этого передадим их в наши реальные экземпляры зданий
    // Эти экземпляры обрабатываются другим классом - Building

    public static BuildingData[] BUILDING_DATA = new BuildingData[]
    {
        new BuildingData("House", 100, new Dictionary<string, int>()
        {
            { "gold", 100 },
            { "wood", 120 }
        }),
        new BuildingData("Tower", 100, new Dictionary<string, int>()
        {
            { "gold", 80 },
            { "wood", 80 },
            { "stone", 100 }
        }),
    };


    // Для некоторых программистов глобальные / статические переменные не являются хорошим шаблоном кодирования.
    // При использовании глобальных переменных, если у вас возникает ошибка, эта переменная доступна из каждой функции в вашем коде, поэтому трудно отследить, откуда исходит ошибка.
    // Поэтому важно знать, где вы используете переменную, чтобы вы могли отслеживать ошибки вплоть до правильных функций.
    // Иногда лучше использовать шаблоны, подобные одноэлементному шаблону.
    // Но это сложнее внедрить, и здесь это не обязательно, потому что мы используем это значение довольно узко в нашем проекте, и не должно быть никаких неконтролируемых побочных эффектов.

    public static Dictionary<string, GameResource> GAME_RESOURCES =
        new Dictionary<string, GameResource>()
    {
        { "gold", new GameResource("Gold", 300) },
        { "wood", new GameResource("Wood", 300) },
        { "stone", new GameResource("Stone", 300) }
    };


    // просто создание глобального списка выбранных юнитов

    public static List<UnitManager> SELECTED_UNITS = new List<UnitManager>();
}