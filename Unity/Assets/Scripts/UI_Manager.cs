using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private bool m_IsGameScene;
    [SerializeField] private PlayerInputs m_Inputs;
    [SerializeField, TitleGroup("In-Game")] private GameObject m_PauseMenu;
    [SerializeField, TitleGroup("In-Game")] private GameObject m_PauseFirstSelect;
    [SerializeField, TitleGroup("In-Game")] private GameObject m_GameOverMenu;
    [SerializeField, TitleGroup("In-Game")] private GameObject m_GameOverFirstSelect;

    private EventSystem m_EventSystem;

    private void Awake()
    {
        m_EventSystem = EventSystem.current;
    }

    private void Update()
    {
        if (m_IsGameScene && m_Inputs.Menu) SetPauseMenu(m_PauseMenu.activeInHierarchy ? 0 : 1);
    }

    public void SetPauseMenu(int active)
    {
        m_PauseMenu.SetActive(active > 0);
        if (active > 0) SetSelected(m_PauseFirstSelect);
    }
    public void SetGameOverMenu(int active)
    {
        m_GameOverMenu.SetActive(active > 0);
        if (active > 0) SetSelected(m_GameOverFirstSelect);
    }

    private void SetSelected(GameObject selected)
    {
        m_EventSystem.SetSelectedGameObject(selected);
    }
}
