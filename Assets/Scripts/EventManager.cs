/* Adapted from:
 * https://learn.unity.com/tutorial/create-a-simple-messaging-system-with-events#5cf5960fedbc2a281acd21fa */

// Простая адаптация учебной сессии Unity по созданию системы обмена сообщениями с помощью событий дает нам следующий сценарий:

// Это словарь событий C#, обозначенных именами (в виде строк), и он использует Одноэлементный шаблон (Singleton pattern)

// Благодаря событиям вы разрываете связь между менеджером игроков и системой пользовательского интерфейса (прямое обращение через ссылку).
// Вместо этого ваш менеджер игроков просто отправит событие, которое может быть перехваченным системой пользовательского интерфейса,
// если она есть, или проигнорированным в противном случае.

using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, CustomEvent> _typedEvents;


    private Dictionary<string, UnityEvent> _events;
    private static EventManager _eventManager;

    public static EventManager instance
    {
        get
        {
            if (!_eventManager)
            {
                _eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!_eventManager)
                    Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene.");
                else
                    _eventManager.Init();
            }

            return _eventManager;
        }
    }


    void Init()
    {
        if (_events == null)
        {
            _events = new Dictionary<string, UnityEvent>();
            _typedEvents = new Dictionary<string, CustomEvent>();
        }
    }


    public static void AddListener(string eventName, UnityAction listener)
    {
        UnityEvent evt = null;
        if (instance._events.TryGetValue(eventName, out evt))
        {
            evt.AddListener(listener);
        }
        else
        {
            evt = new UnityEvent();
            evt.AddListener(listener);
            instance._events.Add(eventName, evt);
        }
    }

    public static void RemoveListener(string eventName, UnityAction listener)
    {
        if (_eventManager == null) return;
        UnityEvent evt = null;
        if (instance._events.TryGetValue(eventName, out evt))
            evt.RemoveListener(listener);
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent evt = null;
        if (instance._events.TryGetValue(eventName, out evt))
            evt.Invoke();
    }


    // Этот пример позволяет нам создавать события, отправляя вместе с ними данные BuildingData типа.

    public static void AddTypedListener(string eventName, UnityAction<CustomEventData> listener)
    {
        CustomEvent evt = null;
        if (instance._typedEvents.TryGetValue(eventName, out evt))
        {
            evt.AddListener(listener);
        }
        else
        {
            evt = new CustomEvent();
            evt.AddListener(listener);
            instance._typedEvents.Add(eventName, evt);
        }
    }

    public static void RemoveTypedListener(string eventName, UnityAction<CustomEventData> listener)
    {
        if (_eventManager == null) return;
        CustomEvent evt = null;
        if (instance._typedEvents.TryGetValue(eventName, out evt))
            evt.RemoveListener(listener);
    }

    public static void TriggerTypedEvent(string eventName, CustomEventData data)
    {
        CustomEvent evt = null;
        if (instance._typedEvents.TryGetValue(eventName, out evt))
            evt.Invoke(data);
    }
}


// еще один словарь пользовательских событий на будущее
// Этот класс используется аналогично объединениям C (C - Unions): мы определяем несколько полей, но используем только одно за раз.

public class CustomEventData
{
    public BuildingData buildingData;

    public CustomEventData(BuildingData buildingData)
    {
        this.buildingData = buildingData;
    }
}

[System.Serializable]
public class CustomEvent : UnityEvent<CustomEventData> { }