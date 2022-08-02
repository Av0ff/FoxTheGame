using UnityEngine;
using UnityEngine.AI;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private NavMeshAgent foxAgent;

    private Fox character;

    [SerializeField]
    private Predator targetPredator;

    public LayerMask Enemy;

    [SerializeField]
    private GameObject _gameOverPanel;

    [SerializeField]
    private GameObject _buttonHome;

    private Vector3 _offset;

    private void Awake()
    {
        _gameOverPanel.SetActive(false);
        character = GetComponent<Fox>();
        _camera = Camera.main;
        foxAgent = gameObject.GetComponent<NavMeshAgent>();
        foxAgent.ResetPath();
        foxAgent.speed = character.PredatorSpeed;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray();
            RayEnemy();
            if (targetPredator != null && !(targetPredator is Fox)) character.Attack(targetPredator);
            targetPredator = null;
        }
        if (character.Health <= 0)
        {
            _gameOverPanel.SetActive(true);
            _buttonHome.SetActive(false);
            character.Death();
        }
    }

    private void Ray()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
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
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit,Enemy.value))
        {
            if (hit.collider)
            {
                _offset = hit.point - transform.position;
                if(_offset.magnitude < 30f)
                {
                    targetPredator = hit.collider.GetComponent<Predator>();
                }
               
            }
        }
    }
}
