using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Trap_Test : Trap
{
    [SerializeField, TitleGroup("Type Specific")] private Renderer m_Rend;
    [SerializeField, TitleGroup("Type Specific")] private Color m_ActivatedColor = new Color(1f, 0f, 0f, 1f);

    protected override void SetToPostActivation()
    {
        m_Rend.material.color = m_ActivatedColor;
    }

    protected override void SpringTrap(GameObject playerObj)
    {
        m_Rend.material.color = m_ActivatedColor;
        
        if(playerObj.TryGetComponent(out Player player))
        {
            player.KillPlayer();
        }
    }
}
