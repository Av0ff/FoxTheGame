using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    private Collider collider;
    private Camera _camera;

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
                hit.collider.GetComponent<Outline>().OutlineWidth = 2;
                collider = hit.collider;
            }
            else
            {
                if (collider != null)
                collider.GetComponent<Outline>().OutlineWidth = 0;
            }
        }
    }
}
