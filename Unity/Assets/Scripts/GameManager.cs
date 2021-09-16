using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadScene(int index)
    {
        //SceneManager.LoadScene(index);
        Invoke("LoadDebug", 1.5f);
    }

    private void LoadDebug()
    {
        SceneManager.LoadScene(1);
    }
}
