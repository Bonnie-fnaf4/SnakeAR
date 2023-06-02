using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SceneLoad(int SceneId)
    {
        SceneManager.LoadScene(SceneId);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
