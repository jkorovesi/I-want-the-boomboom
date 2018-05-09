using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour {

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

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }
}
