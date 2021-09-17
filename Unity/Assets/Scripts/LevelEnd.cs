using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private GameEvent m_VictoryEvent;
    [SerializeField] private E_LayerCompare m_PlayerLayer = E_LayerCompare.Player;
    [SerializeField] private float m_EventDelay = .5f;

    private void OnTriggerEnter(Collider other)
    {
        if(Utilities.CheckCollision(other.gameObject, (int)m_PlayerLayer))
        {
            Invoke("RaiseEvent", m_EventDelay);
        }
    }

    private void RaiseEvent()
    {
        m_VictoryEvent.Raise();
    }
}
