using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Trap : MonoBehaviour
{
    [SerializeField] private TrapTable m_Table;
    
    [SerializeField] private E_LayerCompare m_PlayerLayer = E_LayerCompare.Player;
    [Space(5)]
    [SerializeField] private Renderer m_Rend;
    [SerializeField] private Color m_InactiveColor = new Color(.5f, .5f, .5f, 1f);
    [SerializeField] private Color m_ActiveColor = new Color(1f, 0f, 0f, 1f);

    private void Awake()
    {
        if (!m_Table.Traps.ContainsKey(this))
        {
            m_Table.Traps.Add(this, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Utilities.CheckCollision(other.gameObject, (int)m_PlayerLayer))
        {
            SetSprungValue(true);
        }
    }

    //Remove this ultimately
    private void OnTriggerExit(Collider other)
    {
        if (Utilities.CheckCollision(other.gameObject, (int)m_PlayerLayer))
        {
            SetSprungValue(false);
        }
    }

    private void SetSprungValue(bool sprung)
    {
        m_Table.Traps[this] = sprung;
    }
}
