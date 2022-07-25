using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private NavMeshAgent fox;

    private Fox predatorsSpeed;

    private void Awake()
    {
        predatorsSpeed = GetComponent<Fox>();
        camera = Camera.main;
        fox = gameObject.GetComponent<NavMeshAgent>();
        fox.ResetPath();
        fox.speed = predatorsSpeed.PredatorSpeed;
    }
    void FixedUpdate()
    {
        if(Input.GetMouseButton(1))
        {
            Ray();
        }
    }

    private void Ray()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider)
            {
                fox.SetDestination(hit.point);
            }

        }
    }
}
