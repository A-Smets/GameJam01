using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerKiller : MonoBehaviour
{
    [SerializeField, EnumToggleButtons, HideLabel] private E_CollisionType m_Collision;

    private void OnTriggerEnter(Collider other)
    {
        if (m_Collision == E_CollisionType.Trigger) KillPlayer(other.gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (m_Collision == E_CollisionType.Collision) KillPlayer(collision.gameObject);

    }

    private void OnParticleCollision(GameObject other)
    {
        if (m_Collision == E_CollisionType.Particles) KillPlayer(other.gameObject);

    }

    private void KillPlayer(GameObject playerObj)
    {
        if(playerObj.TryGetComponent(out Player player))
        {
            if (player.m_Active) player.KillPlayer();
        }
    }
}
