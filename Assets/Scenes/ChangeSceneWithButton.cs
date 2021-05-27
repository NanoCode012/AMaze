using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{

    public void LoadScene(string SceneName)
    {
        StartCoroutine(DelaySceneLoad(SceneName));
    }

    IEnumerator DelaySceneLoad(string SceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneName);
    }
}