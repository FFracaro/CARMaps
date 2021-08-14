using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHolder : MonoBehaviour
{
    GameObject PinMap;
    GameObject PinAR;

    PinInfo[] PinInformation;

    public void KeepAlivePinInformation()
    {
        DontDestroyOnLoad(this);
    }

    public void GetAllPins()
    {
        if(PinInformation.Length == 0)
        {
            PinInformation = FindObjectsOfType<PinInfo>();
        }
    }

    private void PinTransfer()
    {

    }

    public void CreateDefaultPinAtParent(Vector3 pos)
    {

    }

    public void CreateDefaultNewPinAR(Vector3 pos)
    {

    }

    public void RecreatePinAR(PinInfo pinInfo)
    {

    }

    public void RecreatePinEditor(PinInfo pinInfo)
    {

    }

    public void DestroyPinInfo()
    {
        Destroy(this);
    }
}
