using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Predator
{
    private void Awake()
    {
        gameObject.GetComponent<Outline>().OutlineWidth = 0;

        Health = 10;
    }

    public override float PredatorSpeed { get { return 10; } }

    public override int Damage => 5;

    public override int LootMeat => 0;

    public override void Attack()
    {
       if(Health != 0)
        {
            Health--;
        }
    }
}
