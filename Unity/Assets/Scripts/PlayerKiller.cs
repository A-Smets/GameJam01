using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerKiller : MonoBehaviour
{
    [SerializeField, HideLabel, EnumToggleButtons] private E_CollisionType m_Type;

    private void OnTriggerEnter(Collider other)
    {
        if (m_Type == E_CollisionType.Trigger) KillPlayer(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (m_Type == E_CollisionType.Collision) KillPlayer(collision.gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (m_Type == E_CollisionType.Particles) KillPlayer(other.gameObject);
    }

    private void KillPlayer(GameObject playerObj)
    {
        if(playerObj.TryGetComponent(out Player player))
        {
            player.KillPlayer();
        }
    }
}
