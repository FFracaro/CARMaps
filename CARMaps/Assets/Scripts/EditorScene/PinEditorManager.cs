using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinEditorManager : MonoBehaviour
{
    private PinInfo pinToEdit;

    [SerializeField]
    TMP_InputField PinNameInput;

    [SerializeField]
    TMP_Dropdown PinColorDropdown;

    public void CloseEditorWindow()
    {
        if(this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void AddPinAlterations()
    {
        string PinName = pinToEdit.GetPinName();

        if (PinNameInput.text != "")
            if (PinNameInput.text != "PLACEHOLDER")
                pinToEdit.SetPinName(PinNameInput.text);

        PinNameInput.text = "";

        int PinColor = pinToEdit.GetPinColor();

        if(PinColorDropdown.value != PinColor)
        {
            pinToEdit.SetPinColor(PinColorDropdown.value);
            pinToEdit.ChancePinSprite(PinColorDropdown.value);
        }

        pinToEdit = null;

        this.gameObject.SetActive(false);
    }

    public void EditPin(PinInfo pin)
    {
        pinToEdit = pin;

        string PinName = pinToEdit.GetPinName();

        if (PinName != "PLACEHOLDER")
            PinNameInput.text = PinName;

        int PinColor = pinToEdit.GetPinColor();

        if (PinColor != PinColorDropdown.value)
            PinColorDropdown.value = PinColor;
    }

    public void DeletePin()
    {
        if(pinToEdit.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
            Destroy(pinToEdit.gameObject);
            pinToEdit = null;
        }
    }
}
