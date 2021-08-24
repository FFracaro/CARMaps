using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditorUI : MonoBehaviour
{
    [SerializeField]
    string SceneToLoad;

    public GameObject OptionsCanvas, MainCanvas, LoadingCanvas;

    public Scrollbar LoadingSlider;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;    
    }

    public void CreateNewPin()
    {
        FindObjectOfType<TouchInputManager>().AddNewPin(true);
    }

    public void GatherAndSavePinInMemory()
    {
        FindObjectOfType<AppInfoHolder>().SetSceneName(SceneToLoad);

        PinHolder ph = FindObjectOfType<PinHolder>();
        ph.SavePinsInfoInMemory();

        ph.AddNextSceneName(SceneToLoad);

        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneToLoad);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void LoadMapScene()
    {
        FindObjectOfType<AppInfoHolder>().SetSceneName(SceneToLoad);
        StartCoroutine(LoadAsyncScene());
    }

    public void OpenOptions()
    {
        if(!OptionsCanvas.activeSelf)
        {
            MainCanvas.SetActive(false);
            OptionsCanvas.SetActive(true);
        }
    }

    public void CloseOptions()
    {
        if(OptionsCanvas.activeSelf)
        {           
            OptionsCanvas.SetActive(false);
            MainCanvas.SetActive(true);
        }
    }

    public void OpenLoadingCanvas(string scene)
    {
        if (OptionsCanvas.activeSelf)
        {        
            LoadingCanvas.SetActive(true);
            OptionsCanvas.SetActive(false);

            Destroy(FindObjectOfType<AppInfoHolder>().gameObject);

            StartCoroutine(LoadScene(scene));
        }
    }

    public void LoadARScene(string scene)
    {
        if (OptionsCanvas.activeSelf)
        {
            LoadingCanvas.SetActive(true);
            OptionsCanvas.SetActive(false);

            FindObjectOfType<AppInfoHolder>().SetSceneName(scene);

            PinHolder ph = FindObjectOfType<PinHolder>();
            ph.SavePinsInfoInMemory();

            ph.AddNextSceneName(scene);

            StartCoroutine(LoadScene(scene));
        }
    }

    IEnumerator LoadScene(string scene)
    {
        yield return new WaitForSeconds(0.6f);

        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

        yield return new WaitForSeconds(0.1f);
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            LoadingSlider.size += Mathf.Clamp01(async.progress / .9f);

            if (async.progress >= 0.9f)
            {
                yield return new WaitForSeconds(0.5f);
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
