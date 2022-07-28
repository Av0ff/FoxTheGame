using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    private Collider prevCollider;
    private Camera cameraMain;
    [SerializeField]
    private InfoPanel panel;

    private void Start()
    {
        cameraMain = Camera.main;
    }

    void Update()
    {
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            if (hit.collider.GetComponent<Outline>())
            {
                hit.collider.GetComponent<Outline>().OutlineWidth = 3;
                prevCollider = hit.collider;
                panel.PanelOn();
                if (Input.GetMouseButtonDown(0))
                {
                  
                }
            }
            else
            {
                if (prevCollider != null)
                prevCollider.GetComponent<Outline>().OutlineWidth = 0;
                panel.PanelOff();
            }
        }
    }
}
