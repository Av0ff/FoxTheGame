using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Predator : MonoBehaviour
{
    public abstract float PredatorSpeed { get; }

    public abstract int Health { get; set; }

    public abstract int Damage { get; }

    public abstract int LootMeat { get; }

    public abstract void Attack(/*Predator predator*/);
}
