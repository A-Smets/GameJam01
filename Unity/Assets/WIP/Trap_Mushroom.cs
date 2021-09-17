using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Trap_Mushroom : Trap
{
    [TitleGroup("Type Specific"), SerializeField] private GameObject m_ActivationVFX;

    protected override void SpringTrap()
    {
        m_ActivationVFX.SetActive(true);
    }
}
