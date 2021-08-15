using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinInfoHolder : MonoBehaviour
{
    public void DontDestroyPinInfoHolder()
    {
        DontDestroyOnLoad(this);
    }

    public void DestroyPinInfoHolder()
    {
        Destroy(this);
    }
}
