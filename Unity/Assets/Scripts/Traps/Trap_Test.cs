using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Test : Trap
{
    [Space(10)]
    [SerializeField] private Renderer m_Rend;
    [SerializeField] private Color m_InactiveColor = new Color(.5f, .5f, .5f, 1f);
    [SerializeField] private Color m_ActiveColor = new Color(1f, 0f, 0f, 1f);

    protected override void SpringTrap(bool spring = true)
    {
        m_Rend.material.color = spring ? m_ActiveColor : m_InactiveColor;
    }
}
