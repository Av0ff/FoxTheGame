using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private Transform target;

    private Fox character;

    private NavMeshAgent fox;

    private void Awake()
    {
        camera = Camera.main;
        character = gameObject.GetComponentInChildren<Fox>();
        fox = GetComponent<NavMeshAgent>();
        fox.ResetPath();
    }
    void FixedUpdate()
    {
        if(Input.GetMouseButton(1))
        {
            Ray();
        }
        //gameObject.transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * character.PredatorSpeed);
        gameObject.transform.LookAt(target);

        if (Vector3.Distance(fox.transform.position, target.position) > 2f)
        {
            fox.isStopped = false;
            fox.SetDestination(target.position);
        }
        else
        {
            //fox.isStopped = true;
            fox.ResetPath();
        }
        
    }

    private void Ray()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider)
            {
                target.position = hit.point;
                target.rotation = Quaternion.FromToRotation(target.up, hit.normal) * target.rotation;
            }
            
        }
    }
}
