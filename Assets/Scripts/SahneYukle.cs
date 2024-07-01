using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneYukle : MonoBehaviour
{
    public void FadeIleSahneYukle(int sceneName)
    {
        SceneTransitionManager.singleton.GoToSceneAsync(sceneName);
    }

    public void YukleSahne(int sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
