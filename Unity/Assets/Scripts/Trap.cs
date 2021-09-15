using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Trap : MonoBehaviour
{
    [SerializeField, ReadOnly] private bool _IsActive;
    public bool IsActive
    {
        get { return _IsActive; }
        set
        {
            _IsActive = value;

            if (m_Rend)
            {
                m_Rend.material.color = _IsActive ? m_ActiveColor : m_InactiveColor;
            }
        }
    }
    [SerializeField] private E_LayerCompare m_PlayerLayer = E_LayerCompare.Player;
    [Space(5)]
    [SerializeField] private Renderer m_Rend;
    [SerializeField] private Color m_InactiveColor = new Color(.5f, .5f, .5f, 1f);
    [SerializeField] private Color m_ActiveColor = new Color(1f, 0f, 0f, 1f);

    private void Awake()
    {
        IsActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Utilities.CheckCollision(other.gameObject, (int)m_PlayerLayer))
        {
            IsActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Utilities.CheckCollision(other.gameObject, (int)m_PlayerLayer))
        {
            IsActive = false;
        }
    }
}
