using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private NavMeshAgent foxAgent;

    private Fox character;

    [SerializeField]
    private Predator targetPredator;

    public LayerMask Enemy;

    private void Awake()
    {
        character = GetComponent<Fox>();
        camera = Camera.main;
        foxAgent = gameObject.GetComponent<NavMeshAgent>();
        foxAgent.ResetPath();
        foxAgent.speed = character.PredatorSpeed;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray();
       // }
        //else if(Input.GetMouseButtonDown(0))
        //{
            RayEnemy();
            if (targetPredator != null && !(targetPredator is Fox)) character.Attack(targetPredator);
            targetPredator = null;
        }
    }

    private void Ray()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider)
            {
                foxAgent.SetDestination(hit.point);
            }
        }
    }


    private void RayEnemy()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit,Enemy.value))
        {
            if (hit.collider)
            {
                targetPredator = hit.collider.GetComponent<Predator>();
            }
        }
    }
}
