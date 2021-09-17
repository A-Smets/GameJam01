using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Rigidbody m_RB;
    [SerializeField] private PlayerInputs m_Inputs;
    [SerializeField] private GameEvent m_DeathEvent;
    [SerializeField] private FloatSO m_MoveSpeed;
    [SerializeField] private FloatSO m_RotationSpeed;
    [SerializeField] private FloatSO m_JumpForce;
    private bool m_MustJump;
    private bool m_Active = true;
    private const float JUMP_MIN_VELOCITY = .05f;
    [ShowInInspector, ReadOnly] private bool CanJump
    {
        get { return m_RB ? !m_MustJump && Mathf.Abs(m_RB.velocity.y) <= JUMP_MIN_VELOCITY : false; }
    }

    private void Awake()
    {
        m_Active = true;
    }
    private void Update()
    {
        if (!m_Active) return;
        AuthorizeJump();

        if (m_Inputs.Y) KillPlayer();
    }
    private void FixedUpdate()
    {
        if (!m_Active) return;
        MovePlayer();
        RotatePlayer();
        Jump();
    }

    private void MovePlayer()
    {
        if (m_RB && m_Inputs)
        {
            float speed = (m_MoveSpeed.Value > m_MoveSpeed.MinValue ? m_MoveSpeed.Value : m_MoveSpeed.MinValue) * Time.deltaTime;
            float x = m_Inputs.HorizontalLeft * speed;
            float y = m_Inputs.VerticalLeft * speed;
            Vector3 camForward = Vector3.Normalize(new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z));
            Vector3 direction = camForward * y + Vector3.Cross(Vector3.up, camForward) * x;

            m_RB.MovePosition(transform.position + direction);
        }
    }
    private void RotatePlayer()
    {
        float x = m_Inputs.HorizontalLeft;
        float y = m_Inputs.VerticalLeft;

        if (x != 0 || y != 0)
        {
            float cameraCorrection = 90f + Camera.main.transform.rotation.eulerAngles.y;
            float angle = Mathf.Atan2(-y, x) * Mathf.Rad2Deg + cameraCorrection;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            float speed = (m_RotationSpeed.Value > m_RotationSpeed.MinValue ? m_RotationSpeed.Value : m_RotationSpeed.MinValue) * Time.smoothDeltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);
        }
    }
    private void AuthorizeJump()
    {
        if (CanJump && m_Inputs.A)
        {
            m_MustJump = true;
        }
    }
    private void Jump()
    {
        if (m_MustJump)
        {
            float force = m_JumpForce.Value > m_JumpForce.MinValue ? m_JumpForce.Value : m_JumpForce.MinValue;
            m_RB.AddForce(Vector3.up * force , ForceMode.Impulse);
            m_MustJump = false;
        }
    }

    public void KillPlayer()
    {
        //Death animation
        m_Active = false;

        m_DeathEvent.Raise();   //Move to end of death animation
    }

    public void OnVictory()
    {
        m_Active = false;
    }
}
