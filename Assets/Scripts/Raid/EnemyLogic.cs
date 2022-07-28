using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour  //������������ ����������� ��� ���� ������ � ����� (��� �������� � ������)
{
    private Bear bear;

    private NavMeshAgent agent;

    public Transform fox;

    public LayerMask whatIsGround, whatIsPlayer;

    public Terrain terr;

    //Patroling
    private Vector3 walkPoint; //������� ������
    private bool walkPointSet; 
    private float walkPointRange; //������� �������

    //Attacking
    private float attackCd; //�� �����
    private bool alreadyAttack; //�������� �� ����� � ������ ������

    //States
    private float sightRange, attackRange; //������� ���������, ������� �����
    private bool playerInSightRange, playerInAttackRange; //�������� �� ��������� � ���� ��������� � �����

    private void Awake()
    {
        bear = GetComponent<Bear>();
        agent = GetComponent<NavMeshAgent>();
        walkPointRange = 50;
        attackCd = 3;
        sightRange = 50;
        attackRange = 5;
        agent.speed = bear.PredatorSpeed;
    }

    private void FixedUpdate()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer); //������ ���������
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer); //������ �����
        
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patroling()
    {

        if (!walkPointSet) SearchWalkPoint();

        if(walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = walkPoint - transform.position;

        if (distanceToWalkPoint.magnitude < 5) walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, terr.SampleHeight(new Vector3(Mathf.RoundToInt(transform.position.x + randomX), 0, Mathf.RoundToInt(transform.position.z + randomZ))), transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 10f, whatIsGround)) walkPointSet = true;

    }
    
    private void ChasePlayer()
    {
        agent.SetDestination(fox.position);
        walkPointSet = false;
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(fox.position);

        if(!alreadyAttack)
        {
            bear.Attack(fox.gameObject.GetComponent<Predator>());

            alreadyAttack = true;
            Invoke(nameof(ResetAttack), attackCd);
        }
    }

    private void ResetAttack() => alreadyAttack = false;
}
