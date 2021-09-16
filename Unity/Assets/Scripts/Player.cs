using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInputs m_Inputs;
    [SerializeField] private GameEvent m_DeathEvent;
    [SerializeField] private Rigidbody m_RB;
    [SerializeField] private FloatSO m_MoveSpeed;
    [SerializeField] private FloatSO m_RotationSpeed;
    [SerializeField] private FloatSO m_JumpForce;
    private bool m_MustJump;
    private bool m_Alive = true;
    private const float JUMP_MIN_VELOCITY = .05f;
    [ShowInInspector, ReadOnly] private bool CanJump
    {
        get { return m_RB ? !m_MustJump && Mathf.Abs(m_RB.velocity.y) <= JUMP_MIN_VELOCITY : false; }
    }

    private void Awake()
    {
        m_Alive = true;
    }
    private void Update()
    {
        if (!m_Alive) return;
        AuthorizeJump();
    }
    private void FixedUpdate()
    {
        if (!m_Alive) return;
        MovePlayer();
        RotatePlayer();
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
    private void RotatePlayer()
    {
        float x = m_Inputs.HorizontalLeft;
        float y = m_Inputs.VerticalLeft;

        if (x != 0 || y != 0)
        {
            float cameraCorrection = 90f + Camera.main.transform.rotation.eulerAngles.y;
            float angle = Mathf.Atan2(-y, x) * Mathf.Rad2Deg + cameraCorrection;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, m_RotationSpeed.Value * Time.smoothDeltaTime);
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
            m_RB.AddForce(Vector3.up * m_JumpForce.Value, ForceMode.Impulse);
            m_MustJump = false;
        }
    }

    public void KillPlayer()
    {
        //Set menu ?
        //Reset scene (or exit if menu)
        Debug.Log("Player has died ! How sad...");
        m_DeathEvent.Raise();
        m_Alive = false;
    }
}
