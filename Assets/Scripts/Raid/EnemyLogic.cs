using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour  //������������ ����������� ��� ���� ������ � ����� (��� �������� � ������)
{
    private Bear _bear;

    private NavMeshAgent _agent;

    public Transform Fox;

    public LayerMask WhatIsGround, WhatIsPlayer;

    public Terrain Terr;

    //Patroling
    private Vector3 _walkPoint; //������� ������
    private bool _walkPointSet; 
    private float _walkPointRange; //������� �������

    //Attacking
    private float _attackCd; //�� �����
    private bool _alreadyAttack; //�������� �� ����� � ������ ������

    //States
    private float _sightRange, _attackRange; //������� ���������, ������� �����
    private bool _playerInSightRange, _playerInAttackRange; //�������� �� ��������� � ���� ��������� � �����

    private void Awake()
    {
        _bear = GetComponent<Bear>();
        _agent = GetComponent<NavMeshAgent>();
        _walkPointRange = 50;
        _attackCd = 3;
        _sightRange = 50;
        _attackRange = 15;
        _agent.speed = _bear.PredatorSpeed;
    }

    private void FixedUpdate()
    {
        if (Fox.gameObject.GetComponent<Fox>().Health > 0)
        {
            _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, WhatIsPlayer); //������ ���������
            _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, WhatIsPlayer); //������ �����

            if (!_playerInSightRange && !_playerInAttackRange) Patroling();
            if (_playerInSightRange && !_playerInAttackRange) ChasePlayer();
            if (_playerInSightRange && _playerInAttackRange) AttackPlayer();
        }
        else
        {
            Patroling();
        }
      
    }

    private void Patroling()
    {

        if (!_walkPointSet) SearchWalkPoint();

        if(_walkPointSet) _agent.SetDestination(_walkPoint);

        Vector3 distanceToWalkPoint = _walkPoint - transform.position;

        if (distanceToWalkPoint.magnitude < 12) _walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);

        _walkPoint = new Vector3(transform.position.x + randomX, Terr.SampleHeight(new Vector3(Mathf.RoundToInt(transform.position.x + randomX), 0, Mathf.RoundToInt(transform.position.z + randomZ))), transform.position.z + randomZ);

        if (Physics.Raycast(_walkPoint, -transform.up, 2f, WhatIsGround)) _walkPointSet = true;

    }
    
    private void ChasePlayer()
    {
        _agent.SetDestination(Fox.position);
        _walkPointSet = false;
    }

    private void AttackPlayer()
    {
        _agent.SetDestination(transform.position);

        transform.LookAt(Fox.position);

        if(!_alreadyAttack)
        {
            _bear.Attack(Fox.gameObject.GetComponent<Predator>());
            _alreadyAttack = true;
            Invoke(nameof(ResetAttack), _attackCd);
        }
    }

    private void ResetAttack() => _alreadyAttack = false;
}
