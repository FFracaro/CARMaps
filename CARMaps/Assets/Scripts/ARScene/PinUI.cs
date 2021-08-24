using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinUI : MonoBehaviour
{
    public GameObject PinText;

    public void OpenClosePinText()
    {
        if (PinText.activeSelf)
            PinText.SetActive(false);
        else
            PinText.SetActive(true);
    }
}
