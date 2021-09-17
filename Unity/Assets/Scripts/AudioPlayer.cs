using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private SoundEvent m_SoundEvent;
    [SerializeField] private AudioSource m_Source;
    [SerializeField] private bool m_PlayOnEnable;

    private void OnEnable()
    {
        if (m_PlayOnEnable) PlayAudio();
    }

    public void PlayAudio()
    {
        m_SoundEvent.Play(m_Source);
    }
}
