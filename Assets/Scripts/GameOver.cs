using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject endText;
    public GameObject blackScreen;
    public GameObject creditsText;

    public IEnumerator PlayGameOver()
    {
        endText.SetActive(true);
        yield return new WaitForSeconds(4f);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        creditsText.SetActive(true);
        yield return new WaitForSeconds(41f);
        StartCoroutine(LoadSceneAsync());
        
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Assets/Scenes/MainMenu.unity");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
