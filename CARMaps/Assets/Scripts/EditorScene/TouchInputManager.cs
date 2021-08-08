using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if(EventSystem.current.IsPointerOverGameObject(0))
            {
                Touch touch = Input.touches[0];
                Vector2 pos = touch.position;
 
                if(touch.phase == TouchPhase.Began)
                {
                    var layerMask = 1 << LayerMask.NameToLayer("UI");

                    Vector3 touchposi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(touchposi, Vector2.zero, 100, layerMask);

                    if (hit && hit.collider != null)
                    {
                        Debug.Log("I'm hitting " + hit.collider.name);
                    }
                }
            }
        }
    }
}
