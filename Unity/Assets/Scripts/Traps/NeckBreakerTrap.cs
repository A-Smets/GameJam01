using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class NeckBreakerTrap : Trap
{
    [SerializeField, TitleGroup("Type Specific")] private Animator m_Animator;
    [SerializeField, TitleGroup("Type Specific")] private string m_AnimatorActivate = "Activate";
    [SerializeField, TitleGroup("Type Specific")] private string m_AnimatorPostActivate = "PostActivate";
    [SerializeField, TitleGroup("Type Specific")] private Collider m_KillerCollider;


    protected override void SpringTrap(GameObject playerObj)
    {
        m_Animator.SetTrigger(m_AnimatorActivate);
        m_KillerCollider.enabled = true;
    }

    protected override void SetPostActivate()
    {
        m_Animator.SetTrigger(m_AnimatorPostActivate);
    }
}
