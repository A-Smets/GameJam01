using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Trap_Mushroom : Trap
{
    [TitleGroup("Type Specific"), SerializeField] private Animator m_Animator;
    [TitleGroup("Type Specific"), SerializeField] private string m_AnimatorActiate = "Activate";
    [TitleGroup("Type Specific"), SerializeField] private string m_AnimatorPostActivate = "PostActivate";
    [TitleGroup("Type Specific"), SerializeField] private GameObject m_ActivationVFX;
    [TitleGroup("Type Specific"), SerializeField] private Collider m_KillerCollider;

    protected override void SpringTrap(GameObject playerObj)
    {
        m_ActivationVFX.SetActive(true);
        m_Animator.SetTrigger(m_AnimatorActiate);
    }

    protected override void SetPostActivate()
    {
        m_Animator.SetTrigger(m_AnimatorPostActivate);
    }

    public void ActivateKiller()
    {
        m_KillerCollider.enabled = true;
    }
}
