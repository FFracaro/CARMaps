using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation.Samples;
using System;

public class ARSceneUI : MonoBehaviour
{
    [SerializeField]
    string SceneToLoad;

    public GameObject OptionsCanvas, MainCanvas, LoadingCanvas, ARCanvas;

    public Scrollbar LoadingSlider;

    public Button ResetButton;

    private bool isObjectPlaced = false;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
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

    public void LoadEditorScene(string scene)
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

    public void ResetScene()
    {
        PlaceObjectOnPlane PlaceObject = FindObjectOfType<PlaceObjectOnPlane>();
        UIManager UIM = FindObjectOfType<UIManager>();
        UIM.ResetAnimations();
        PlaceObject.ResetScene();

        SetIsObjectPlaced(false);

        ResetButtonOn(false);

        if (OptionsCanvas.activeSelf)
        {
            OptionsCanvas.SetActive(false);
            MainCanvas.SetActive(true);
            ARCanvas.SetActive(true);
        }
    }

    public void ResetButtonOn(bool a)
    {
        ResetButton.interactable = a;
    }


    public void OpenOptions()
    {
        if (!OptionsCanvas.activeSelf)
        {
            MainCanvas.SetActive(false);
            OptionsCanvas.SetActive(true);
            ARCanvas.SetActive(false);
        }
    }

    public void CloseOptions()
    {
        if (OptionsCanvas.activeSelf)
        {
            OptionsCanvas.SetActive(false);
            MainCanvas.SetActive(true);

            if (!IsObjectPlaced())
                ARCanvas.SetActive(true);
        }
    }

    public bool IsObjectPlaced()
    {
        return isObjectPlaced;
    }

    public void SetIsObjectPlaced(bool value)
    {
        isObjectPlaced = value;
    }

    public void OpenLoadingCanvas(string scene)
    {
        if (OptionsCanvas.activeSelf)
        {
            if (ARCanvas.activeSelf)
                ARCanvas.SetActive(false);

            LoadingCanvas.SetActive(true);
            OptionsCanvas.SetActive(false);

            Destroy(FindObjectOfType<AppInfoHolder>().gameObject);

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
