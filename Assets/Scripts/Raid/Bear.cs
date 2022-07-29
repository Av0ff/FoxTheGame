using UnityEngine;

public class Bear : Predator
{
    [SerializeField]
    private Fox _fox;

    [SerializeField]
    private GameObject _loot;

    private EnemyKill _enemykill = new();

    [SerializeField]
    private ParticleSystem _dust;

    private void Awake()
    {
       _dust = GameObject.FindObjectOfType<ParticleSystem>();
    }

    private void Update()
    {
        if (Health <= 0)
        {
            Death();
        }
    }

    public override int Health { get; set; } = 20;

    public override int Damage => 3;

    public override int LootMeat => 2;

    public override float PredatorSpeed => 15;

    public override void Attack(Predator predator)
    {
        if (predator is Fox) _fox.Health -= Damage;
    }

    public override void Death()
    {
        _enemykill.SendEnemyKilled();
        Destroy(gameObject);
    }

    private void SpawnLoot()
    {
        for(int i = 0; i < LootMeat; i++)
        {
            Instantiate(_loot, transform.position + Vector3.up, Quaternion.identity);
        }
        
    }

    private void SpawnDust()
    {
        _dust.transform.position = gameObject.transform.position;
        //dust.GetComponent<ParticleSystem>().Play();
        _dust.Play();
    }

    private void OnEnable()
    {
        _enemykill.OnEnemyKilled += SpawnLoot;
        _enemykill.OnEnemyKilled += SpawnDust;
    }

    private void OnDisable()
    {
        _enemykill.OnEnemyKilled -= SpawnLoot;
        _enemykill.OnEnemyKilled -= SpawnDust;
    }
}
