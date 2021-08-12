using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputPin : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject PinText;

    [SerializeField]
    GameObject PinButtons;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(PinText.activeSelf)
        {
            PinText.SetActive(false);
            PinButtons.SetActive(false);
        }
        else
        {
            PinText.SetActive(true);
            PinButtons.SetActive(true);
        }

        Debug.Log("Clicked PIN: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
}