using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField] private Player m_PlayerParent;

    public void Jump()
    {
        m_PlayerParent.Jump();
    }

    public void OnDeath()
    {
        m_PlayerParent.OnDeath();
    }
}
