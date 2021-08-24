using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GeneralUIController : MonoBehaviour
{
    public RectTransform InitialScreen, SelectionScreen, CreditsScreen, LoadingScreen;

    public Scrollbar LoadingSlider;

    public string SceneToLoad;

    public float TweenSpeed;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void OpenSelectionScreen()
    {
        InitialScreen.DOAnchorPos(new Vector2(-750, 0), TweenSpeed);
        SelectionScreen.DOAnchorPos(Vector2.zero, TweenSpeed);
    }

    public void CloseSelectionScreen()
    {
        SelectionScreen.DOAnchorPos(new Vector2(750, 0), TweenSpeed);
        InitialScreen.DOAnchorPos(Vector2.zero, TweenSpeed);
    }

    public void OpenCreditsScreen()
    {
        InitialScreen.DOAnchorPos(new Vector2(-750, 0), TweenSpeed);
        CreditsScreen.DOAnchorPos(Vector2.zero, TweenSpeed);
    }

    public void CloseCreditsScreen()
    {
        CreditsScreen.DOAnchorPos(new Vector2(0, -1250), TweenSpeed);
        InitialScreen.DOAnchorPos(Vector2.zero, TweenSpeed);
    }

    public void OpenLoadingScreen()
    {
        SelectionScreen.DOAnchorPos(new Vector2(750, 0), TweenSpeed);
        LoadingScreen.DOAnchorPos(Vector2.zero, TweenSpeed);

        FindObjectOfType<AppInfoHolder>().SetSceneName(SceneToLoad);

        StartCoroutine(LoadScene(SceneToLoad));
    }

    IEnumerator LoadScene(string SceneToLoad)
    {
        yield return new WaitForSeconds(1f);

        AsyncOperation async = SceneManager.LoadSceneAsync(SceneToLoad);

        yield return new WaitForSeconds(0.1f);
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            LoadingSlider.size += Mathf.Clamp01(async.progress / .9f);

            if(async.progress >= 0.9f)
            {
                yield return new WaitForSeconds(0.1f);
                async.allowSceneActivation = true;
            }

            yield return null;
        }
    }


    public void CloseApp()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }
}
