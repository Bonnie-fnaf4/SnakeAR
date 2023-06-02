using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    public void MenuButton(int SceneLoad)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneLoad);
    }
}
