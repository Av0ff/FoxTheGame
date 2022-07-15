using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    private Collider collider;
    private Camera _camera;
    [SerializeField]
    private InfoPanel panel;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            if (hit.collider.GetComponent<Outline>())
            {

                hit.collider.GetComponent<Outline>().OutlineWidth = 3;
                collider = hit.collider;
                panel.PanelOn();
                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<Fox>().Attack();
                }
            }
            else
            {
                if (collider != null)
                collider.GetComponent<Outline>().OutlineWidth = 0;
                panel.PanelOff();
            }
        }
    }
}
