using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class Trap : MonoBehaviour
{
    [InfoBox("Unique BoolSO must be created for each trap", InfoMessageType = InfoMessageType.Warning, VisibleIf = "@m_WasSprung == null")]
    [SerializeField, TitleGroup("Base Trap Data")] private BoolSO m_WasSprung;
    [SerializeField, TitleGroup("Base Trap Data")] private Collider m_TriggerCollider;
    [SerializeField, TitleGroup("Base Trap Data")] private E_LayerCompare m_PlayerLayer = E_LayerCompare.Player;
    [SerializeField, TitleGroup("Base Trap Data"), Range(0,1)] private float m_ActivationChance = 1;

    private void Awake()
    {
        if (m_WasSprung.Value) PostActivate();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(Utilities.CheckCollision(other.gameObject, (int)m_PlayerLayer))
        {
            if(Random.value <= m_ActivationChance) Activate(other.gameObject);
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
        SetPostActivate();
    }

    protected abstract void SpringTrap(GameObject playerObj);

    protected abstract void SetPostActivate();
}
