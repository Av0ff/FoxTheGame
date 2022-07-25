using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Predator
{
    public Fox fox;

    private void Awake()
    {
        
    }

    public override int Health { get; set; } = 20;

    public override int Damage => 3;

    public override int LootMeat => 2;

    public override float PredatorSpeed => 15;

    public override void Attack()
    {
        fox.Health -= Damage;
    }
}
