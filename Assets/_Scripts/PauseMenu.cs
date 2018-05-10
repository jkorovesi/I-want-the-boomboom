using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public bool isPaused;
    public GameObject pauseMenu;

    public AudioSource source;
    public AudioClip clickSound;
    public AudioClip hoverSound;

    public void OnHover()
    {
        source.PlayOneShot(hoverSound);
    }

    public void OnClick()
    {
        source.PlayOneShot(clickSound);
    }

    // Update is called once per frame
    void Update () {


        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


}
