using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public Animator transition;

    public void transitionNextScene(string sceneName)
    {
        StartCoroutine(TransitionScene(sceneName));
    }

    IEnumerator TransitionScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneName);
    }
}
