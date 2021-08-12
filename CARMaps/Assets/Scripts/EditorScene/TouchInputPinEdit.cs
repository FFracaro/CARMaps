using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputPinEdit : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject EditCanvas;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!EditCanvas.activeSelf)
        {
            EditCanvas.GetComponent<PinEditorManager>().EditPin(GetComponentInParent<PinInfo>());
            EditCanvas.SetActive(true);
        }
    }

}
