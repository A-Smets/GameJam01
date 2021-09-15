using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/GameEvent")]
public class GameEvent : ScriptableObject
{
    [SerializeField, ReadOnly] private List<UnityEvent> listeners = new List<UnityEvent>();

    public void Raise()
    {
        foreach (var unityEvent in listeners)
        {
            unityEvent.Invoke();
        }
    }

    public void Register(UnityEvent listener)
    {
        listeners.Add(listener);
    }

    public void Unregister(UnityEvent listener)
    {
        listeners.Remove(listener);
    }

    private void OnDisable()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            Unregister(listeners[i]);
        }
    }
}
