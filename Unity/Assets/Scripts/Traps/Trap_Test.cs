using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Trap_Test : Trap
{
    [SerializeField, TitleGroup("Type Specific")] private Renderer m_Rend;
    [SerializeField, TitleGroup("Type Specific")] private Color m_ActivatedColor = new Color(1f, 0f, 0f, 1f);

    protected override void SpringTrap()
    {
        m_Rend.material.color = m_ActivatedColor;
    }
}
