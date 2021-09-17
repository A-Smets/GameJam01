using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SteamTrap : Trap
{
    [TitleGroup("Type Specific"), SerializeField] private GameObject m_PreActivationVFX;
    [TitleGroup("Type Specific"), SerializeField] private GameObject m_ActivationVFX;
    [TitleGroup("Type Specific"), SerializeField] private GameObject m_PostActivationVFX;

    protected override void SpringTrap(GameObject playerObj)
    {
        //Valve anim
        m_ActivationVFX.SetActive(true);
        m_PreActivationVFX.SetActive(false);
    }

    protected override void SetPostActivate()
    {
        m_PreActivationVFX.SetActive(false);
        m_ActivationVFX.SetActive(false);
        m_PostActivationVFX.SetActive(true);
        //Remove valve
    }
}
