using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInputs m_Inputs;
    [SerializeField] private Rigidbody m_RB;
    [SerializeField] private FloatSO m_MoveSpeed;
    [SerializeField] private FloatSO m_JumpForce;
    private bool m_MustJump;
    [SerializeField, ReadOnly] private bool CanJump
    {
        get { return !m_MustJump && m_RB.velocity.y == 0; }
    }
    

    private void Update()
    {
        if (CanJump && m_Inputs.A)
        {
            m_MustJump = true;
        }   
    }

    private void FixedUpdate()
    {
        MovePlayer();
        Jump();
    }

    private void MovePlayer()
    {
        if (m_RB && m_Inputs)
        {
            float x = m_Inputs.HorizontalLeft * m_MoveSpeed.Value * Time.deltaTime;
            float y = m_Inputs.VerticalLeft * m_MoveSpeed.Value * Time.deltaTime;
            Vector3 camForward = Vector3.Normalize(new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z));
            Vector3 direction = camForward * y + Vector3.Cross(Vector3.up, camForward) * x;

            m_RB.MovePosition(transform.position + direction);
        }
    }

    private void Jump()
    {
        if (m_MustJump)
        {
            m_RB.AddForce(Vector3.up * m_JumpForce.Value, ForceMode.Impulse);
            m_MustJump = false;
        }
    }
}
