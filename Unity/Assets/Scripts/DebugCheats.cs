using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DebugCheats : MonoBehaviour
{
    public PlayerInputs m_Inputs;
    [ReadOnly, Range(-1,1)] public float m_HorizontalLeft;
    [ReadOnly, Range(-1, 1)] public float m_VerticalLeft;
    [ReadOnly, Range(-1, 1), Space()] public float m_HorizontalRight;

    void Update()
    {
        m_HorizontalLeft = m_Inputs.HorizontalLeft;
        m_VerticalLeft = m_Inputs.VerticalLeft;
        m_HorizontalRight = m_Inputs.HorizontalRight;
    }
}
