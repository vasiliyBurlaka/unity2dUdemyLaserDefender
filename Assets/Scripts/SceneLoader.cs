using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene() {
        SceneManager.LoadScene("LaserDefender");
    }

    public void LoadStartScene() {
        SceneManager.LoadScene("Start");
    }

    public void LoadGameOverScene() {
        SceneManager.LoadScene("GameOver");
    }

    public void Quit()
    {
        Application.Quit();
    }
}