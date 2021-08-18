using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class PinHolder : MonoBehaviour
{
    public GameObject PinMap;
    public GameObject PinAR;

    PinInfo[] PinInformation;

    AppInfoHolder AppInfo;

    bool EditorScene = false;

    private void Start()
    {
        AppInfo = FindObjectOfType<AppInfoHolder>();

        if(AppInfo.GetSceneName() == "MapEditor")
        {
            EditorScene = true;
            LoadPinsFromMemory();
        }
        else
        {
            EditorScene = false;
        }    
    }

    public void AddNextSceneName(string scene)
    {
        AppInfo.SetSceneName(scene);
    }

    public void SavePinsInfoInMemory()
    {
        if(GetAllPins() > 0)
        {
            PinsTransfer();
        }
    }

    public void LoadPinsFromMemory()
    {
        List<Pin> Pins = AppInfo.GetPinList();

        if(Pins != null)
        {
            if(Pins.Count > 0)
            {
                InstantiatePins(Pins);
            }
        }
    }

    private GameObject GetChildMapReference()
    {
        GameObject map = GameObject.Find("VilaA");
        return map.transform.GetChild(0).gameObject;
    }

    private void InstantiatePins(List<Pin> pins)
    {
        GameObject PinObject = GetChildMapReference();

        foreach (Pin p in pins)
        {
            if(EditorScene)
            {
                CreatePin(p, PinMap, PinObject);
            }
            else
            {
                CreatePin(p, PinAR, PinObject);
            }
        }
    }

    private void CreatePin(Pin p, GameObject pinToInstantiate, GameObject target)
    {
        PinInfo info;

        //Debug.Log("LOCAL CREATE " + new System.Numerics.Vector3(p.GetPinLocalPosition()[0], p.GetPinLocalPosition()[1], p.GetPinLocalPosition()[2]));

        GameObject go = Instantiate(pinToInstantiate, new UnityEngine.Vector3(p.GetPinLocalPosition()[0], p.GetPinLocalPosition()[1], p.GetPinLocalPosition()[2]), UnityEngine.Quaternion.identity) as GameObject;
        go.transform.SetParent(target.transform);

        info = go.GetComponent<PinInfo>();

        info.SetPinColor(p.GetPinColor());
        info.UpdatePinSprite(p.GetPinColor());

        info.UpdatePinLocations(new UnityEngine.Vector3(p.GetPinLocalPosition()[0], p.GetPinLocalPosition()[1], p.GetPinLocalPosition()[2]), new UnityEngine.Vector3(p.GetPinWorldPosition()[0], p.GetPinWorldPosition()[1], p.GetPinWorldPosition()[2]));
        info.SetPinName(p.GetPinName());
    }

    public int GetAllPins()
    {
        PinInformation = FindObjectsOfType<PinInfo>();

        return PinInformation.Length;
    }

    public void PinsTransfer()
    {
        List<Pin> pins = new List<Pin>();

        Pin p;

        foreach(PinInfo pin in PinInformation)
        {
            p = new Pin();

            //SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;

            p.SetPinName(pin.GetPinName());
            p.SetPinColor(pin.GetPinColor());
            p.SetPinLocalPosition(pin.GetPinLocalPosition().x, pin.GetPinLocalPosition().y, pin.GetPinLocalPosition().z);

            //Debug.Log("LOCAL SAVING " + new System.Numerics.Vector3(pin.GetPinLocalPosition().x, pin.GetPinLocalPosition().y, pin.GetPinLocalPosition().z));
            p.SetPinWorldPosition(pin.GetPinWorldPosition().x, pin.GetPinWorldPosition().y, pin.GetPinWorldPosition().z);

            pins.Add(p);
        }

        AppInfo.SetPinList(pins);
    }
}
