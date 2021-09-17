using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamTrapAnimEvents : MonoBehaviour
{
    [SerializeField] private SteamTrap m_TrapParent;
    [SerializeField] private ParticleSystem m_IdlePS;

    private void SpawnIdlePS()
    {
        if (m_IdlePS.gameObject.activeInHierarchy && !m_IdlePS.isPlaying)
        {
            m_IdlePS.gameObject.transform.Rotate(Vector3.forward, Random.Range(0, 360));
            m_IdlePS.Play();
        }
    }

    private void HideYeetable()
    {
        m_TrapParent.HideYeetable();
    }
}
