using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "ScriptableObjects/Trap Reset")]
public class TrapResetter : ScriptableObject
{
    [SerializeField] private BoolSO[] m_TrapStates;

    [Button] public void ResetAll()
    {
        for (int i = 0; i < m_TrapStates.Length; i++)
        {
            m_TrapStates[i].Value = false;
        }
    }
}
