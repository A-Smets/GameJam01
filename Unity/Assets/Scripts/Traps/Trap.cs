using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class Trap : MonoBehaviour
{
    [SerializeField] private BoolSO m_WasSprung;
    [SerializeField] private Collider m_TriggerCollider;
    [SerializeField] private E_LayerCompare m_PlayerLayer = E_LayerCompare.Player;
    [SerializeField] private bool m_UnspringDEBUG;

    private void Awake()
    {
        if (!m_UnspringDEBUG && m_WasSprung.Value) Activate();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(Utilities.CheckCollision(other.gameObject, (int)m_PlayerLayer))
        {
            Activate();
            if(other.TryGetComponent(out Player player))
            {
                player.KillPlayer();
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (Utilities.CheckCollision(other.gameObject, (int)m_PlayerLayer))
        {
            if (m_UnspringDEBUG) Activate(false);
        }
    }

    private void Activate(bool spring = true)
    {
        m_WasSprung.Value = spring;
        m_TriggerCollider.enabled = !spring;
        SpringTrap(spring);
    }

    protected abstract void SpringTrap(bool spring = true);
}
