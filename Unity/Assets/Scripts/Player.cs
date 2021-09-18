using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour
{
    [SerializeField, TitleGroup("Components")] private Rigidbody m_RB;
    [SerializeField, TitleGroup("Components")] private PlayerInputs m_Inputs;
    [SerializeField, TitleGroup("Components")] private GameEvent m_DeathEvent;
    [SerializeField, TitleGroup("Movement")] private FloatSO m_MoveSpeed;
    [SerializeField, TitleGroup("Movement")] private FloatSO m_RotationSpeed;
    [SerializeField, TitleGroup("Movement")] private FloatSO m_JumpForce;
    [SerializeField, TitleGroup("Movement"), Range(1f, 5f)] private float m_FallSpeedUp;
    [SerializeField, TitleGroup("Animation")] private Animator m_Animator;
    [SerializeField, TitleGroup("Animation")] private string m_AnimatorMove;
    [SerializeField, TitleGroup("Animation")] private string m_AnimatorJumpStart;
    [SerializeField, TitleGroup("Animation")] private string m_AnimatorJumpEnd;
    [SerializeField, TitleGroup("Animation")] private string m_AnimatorDeath;  
    [SerializeField, TitleGroup("Animation")] private string m_AnimatorIdleBreak;
    [SerializeField, TitleGroup("Animation")] private float m_IdleBreakThreshold = 3;
    [SerializeField, TitleGroup("Animation"), ReadOnly] private float m_IdleBreakTimer;
    private bool m_IsJumping;
    private bool m_IncrementIdleTimer = true;
    private float m_JumpCD;
    [SerializeField, ReadOnly] private bool m_Active = true;
    private const float JUMP_MIN_VELOCITY = .05f;
    [ShowInInspector, ReadOnly, TitleGroup("Components")] private bool CanJump
    {
        get { return m_RB ? Mathf.Abs(m_RB.velocity.y) <= JUMP_MIN_VELOCITY : false; }
    }

    private void Awake()
    {
        m_Active = true;
        m_JumpCD = 0;
    }
    private void Update()
    {
        if (m_Inputs.Menu) SetActive(!m_Active);
        if (!m_Active) return;
        ManageJump();

        if (m_Inputs.Y) KillPlayer();
    }
    private void FixedUpdate()
    {
        if (!m_Active) return;
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        if (m_RB && m_Inputs)
        {
            float speed = (m_MoveSpeed.Value > m_MoveSpeed.MinValue ? m_MoveSpeed.Value : m_MoveSpeed.MinValue) * Time.deltaTime;
            float x = m_Inputs.HorizontalLeft;
            float y = m_Inputs.VerticalLeft;
            Vector3 camForward = Vector3.Normalize(new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z));
            Vector3 direction = camForward * y * speed + Vector3.Cross(Vector3.up, camForward) * x * speed;

            m_RB.MovePosition(transform.position + direction);
            float magnitude = new Vector2(x, y).magnitude;
            m_Animator.SetFloat(m_AnimatorMove, magnitude);

            if (m_IncrementIdleTimer && magnitude == 0) m_IdleBreakTimer += Time.deltaTime;
            if (m_IdleBreakTimer >= m_IdleBreakThreshold)
            {
                m_Animator.SetTrigger(m_AnimatorIdleBreak);
                m_IdleBreakTimer = 0;
                m_IncrementIdleTimer = false;
                Invoke("AuthorizeIdleTimer", m_IdleBreakThreshold);
            }
        }
    }

    private void AuthorizeIdleTimer()
    {
        m_IncrementIdleTimer = true;
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
            m_IdleBreakTimer = 0;
        }
    }
    private void ManageJump()
    {
        if (CanJump && m_Inputs.A && m_JumpCD <= Time.timeSinceLevelLoad) m_Animator.SetTrigger(m_AnimatorJumpStart);

        //Land
        if (m_IsJumping && Mathf.Abs(m_RB.velocity.y) <= JUMP_MIN_VELOCITY * 10)
        {
            m_Animator.SetTrigger(m_AnimatorJumpEnd);
            m_IsJumping = false;
        }
        //Speed up fall
        if (m_RB.velocity.y < 0) m_RB.velocity += Vector3.up * Physics.gravity.y * (m_FallSpeedUp - 1) * Time.deltaTime;

    }
    public void Jump()
    {
        float force = m_JumpForce.Value > m_JumpForce.MinValue ? m_JumpForce.Value : m_JumpForce.MinValue;
        m_RB.AddForce(Vector3.up * force, ForceMode.Impulse);
        m_IsJumping = true;
    }

    public void KillPlayer()
    {
        m_Animator.SetTrigger(m_AnimatorDeath);
        m_Active = false;
    }

    public void OnDeath()
    {
        m_DeathEvent.Raise();
    }

    public void OnVictory()
    {
        m_Active = false;
    }

    public void SetActive(bool value)
    {
        m_JumpCD = Time.timeSinceLevelLoad + .05f;
        m_Active = value;
    }
}
