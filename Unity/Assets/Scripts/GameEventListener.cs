using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
public class GameEventListener : MonoBehaviour
{
    [SerializeField, ListDrawerSettings(NumberOfItemsPerPage = 3)] private List<GameEventResponse> m_EventResponses;

    private void OnEnable()
    {
        foreach (var eventResponse in m_EventResponses)
        {
            eventResponse.Register();
        }
    }

    private void OnDisable()
    {
        foreach (var eventResponse in m_EventResponses)
        {
            eventResponse.Unregister();
        }
    }
}