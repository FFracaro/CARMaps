using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHolder : MonoBehaviour
{
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

    public void DestroyPinInfo()
    {
        Destroy(this);
    }
}
