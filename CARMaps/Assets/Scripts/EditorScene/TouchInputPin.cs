using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputPin : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject PinText;

    [SerializeField]
    bool HasExtraButtons = false;

    [SerializeField]
    GameObject PinButtons;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(PinText.activeSelf)
        {
            PinText.SetActive(false);
            if(HasExtraButtons)
                PinButtons.SetActive(false);
        }
        else
        {
            PinText.SetActive(true);
            if(HasExtraButtons)
                PinButtons.SetActive(true);
        }

        Debug.Log("Clicked PIN: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
}