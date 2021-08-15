using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppInfoHolder : MonoBehaviour
{
    [SerializeField]
    string SceneName;

    private List<Pin> Pins;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public string GetSceneName()
    {
        return this.SceneName;
    }

    public void SetSceneName(string scene)
    {
        this.SceneName = scene;
    }

    public void DestroyInfoHolder()
    {
        Destroy(this);
    }

    public void SetPinList(List<Pin> pins)
    {
        Pins = pins;
    }

    public List<Pin> GetPinList()
    {
        return Pins;
    }
}
