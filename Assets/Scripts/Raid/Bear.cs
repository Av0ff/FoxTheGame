using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Predator
{
    [SerializeField]
    private Fox fox;

    private Outline outline;

    [SerializeField]
    private GameObject loot;

    private EnemyKill enemykill = new();

    private void Awake()
    {
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 0;
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
        if (predator is Fox) fox.Health -= Damage;
    }

    public override void Death()
    {
        enemykill.SendEnemyKilled();
        Destroy(gameObject);
    }

    private void SpawnLoot()
    {
        for(int i = 0; i < LootMeat; i++)
        {
            Instantiate(loot, transform.position, Quaternion.identity);
        }
        
    }

    private void OnEnable()
    {
        enemykill.OnEnemyKilled += SpawnLoot;
    }

    private void OnDisable()
    {
        enemykill.OnEnemyKilled -= SpawnLoot;
    }
}
