using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditorUI : MonoBehaviour
{

    [SerializeField]
    string SceneToLoad;

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
}
