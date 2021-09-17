using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SteamTrap : Trap
{
    [TitleGroup("Type Specific"), SerializeField] private Animator m_Animator;
    [TitleGroup("Type Specific"), SerializeField] private string m_AnimatorActivate = "Activate";
    [TitleGroup("Type Specific"), SerializeField] private string m_AnimatorPostActivate = "PostActivate";
    [TitleGroup("Type Specific"), SerializeField] private GameObject m_PreActivationVFX;
    [TitleGroup("Type Specific"), SerializeField] private GameObject m_ActivationVFX;
    [TitleGroup("Type Specific"), SerializeField] private GameObject m_PostActivationVFX;
    [SerializeField] private GameObject m_YeetablePiece;

    protected override void SpringTrap(GameObject playerObj)
    {
        m_Animator.SetTrigger(m_AnimatorActivate);
        m_ActivationVFX.SetActive(true);
        m_PreActivationVFX.SetActive(false);
    }

    protected override void SetPostActivate()
    {
        m_Animator.SetTrigger(m_AnimatorPostActivate);
        m_PreActivationVFX.SetActive(false);
        m_ActivationVFX.SetActive(false);
        HideYeetable();
        //m_PostActivationVFX.SetActive(true);
    }

    public void HideYeetable()
    {
        m_YeetablePiece.SetActive(false);
    }
}
