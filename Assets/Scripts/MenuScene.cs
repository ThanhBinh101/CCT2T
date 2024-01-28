using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public GameObject menuScene;
    // Start is called before the first frame update
    void Start()
    {
        Pause();
    }

    // Update is called once per frame


    public void Restart()
    {
        // Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        menuScene.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        menuScene.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
