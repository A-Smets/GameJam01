using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void CloseGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
