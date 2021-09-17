using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook m_Cam;
    private float m_CamSpeed;

    private void Awake()
    {
        m_CamSpeed = m_Cam.m_XAxis.m_MaxSpeed;
    }

    public void BlockCam(bool block)
    {
        m_Cam.m_XAxis.m_MaxSpeed = block ? 0 : m_CamSpeed;
    }
}
