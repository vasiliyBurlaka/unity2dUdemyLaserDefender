using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float pauseBeforeLoadGameOver = 3f;

    public void LoadGameScene() {
        SceneManager.LoadScene("LaserDefender");
        FindObjectOfType<Score>().ResetScore();
    }

    public void LoadStartScene() {
        SceneManager.LoadScene("Start");
    }

    public void LoadGameOverScene() {
        StartCoroutine(WaitAndLoadScene("GameOver"));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoadScene(string SceneName = "")
    {
        yield return new WaitForSeconds(pauseBeforeLoadGameOver);
        SceneManager.LoadScene(SceneName);
    }
}