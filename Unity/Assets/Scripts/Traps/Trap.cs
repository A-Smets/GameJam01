using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class Trap : MonoBehaviour
{
    [SerializeField, TitleGroup("Base Trap Data"), InfoBox("Unique BoolSO must be created for each trap", InfoMessageType = InfoMessageType.Warning)] private BoolSO m_WasSprung;
    [SerializeField, TitleGroup("Base Trap Data")] private Collider m_TriggerCollider;
    [SerializeField, TitleGroup("Base Trap Data")] private E_LayerCompare m_PlayerLayer = E_LayerCompare.Player;

    private void Awake()
    {
        if (m_WasSprung.Value) Activate();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(Utilities.CheckCollision(other.gameObject, (int)m_PlayerLayer))
        {
            Activate();
            /*
            if(other.TryGetComponent(out Player player))
            {
                player.KillPlayer();
            }
            */
        }
    }

    private void Activate()
    {
        m_WasSprung.Value = true;
        m_TriggerCollider.enabled = false;
        SpringTrap();
    }

    protected abstract void SpringTrap();
}
