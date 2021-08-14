using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceHolder : MonoBehaviour
{
    [SerializeField]
    GameObject EditCanvas;

    public GameObject GetEditCanvasReference()
    {
        return EditCanvas;
    }
}
