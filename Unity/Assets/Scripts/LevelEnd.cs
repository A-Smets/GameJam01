using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private GameEvent m_VictoryEvent;
    [SerializeField] private E_LayerCompare m_PlayerLayer = E_LayerCompare.Player;

    private void OnTriggerEnter(Collider other)
    {
        if(Utilities.CheckCollision(other.gameObject, (int)m_PlayerLayer))
        {
            m_VictoryEvent.Raise();
        }
    }
}
