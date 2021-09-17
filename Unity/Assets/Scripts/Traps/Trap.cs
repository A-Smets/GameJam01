using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class Trap : MonoBehaviour
{
    [SerializeField, TitleGroup("Base Trap Data")] private BoolSO m_WasSprung;
    [SerializeField, TitleGroup("Base Trap Data")] private Collider m_TriggerCollider;
    [SerializeField, TitleGroup("Base Trap Data")] private E_LayerCompare m_PlayerLayer = E_LayerCompare.Player;

    private void Awake()
    {
        if (m_WasSprung.Value) PostActivate();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(Utilities.CheckCollision(other.gameObject, (int)m_PlayerLayer))
        {
            Activate(other.gameObject);
        }
    }

    private void Activate(GameObject playerObj)
    {
        m_WasSprung.Value = true;
        m_TriggerCollider.enabled = false;
        SpringTrap(playerObj);
    }
    private void PostActivate()
    {
        m_TriggerCollider.enabled = false;
        SetToPostActivation();
    }

    protected abstract void SpringTrap(GameObject playerObj);
    protected abstract void SetToPostActivation();
}
