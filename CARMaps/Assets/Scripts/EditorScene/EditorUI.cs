using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorUI : MonoBehaviour
{
    public void CreateNewPin()
    {
        FindObjectOfType<TouchInputManager>().AddNewPin(true);
    }
}
