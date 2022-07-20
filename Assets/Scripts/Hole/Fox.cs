using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Predator
{
    private void Awake()
    {
        //gameObject.GetComponent<Outline>().OutlineWidth = 0;
        if(TryGetComponent<Outline>(out Outline outline))
        {   
            outline.OutlineWidth = 0;
        }
        //Проверка хп после вылазки, где нас могут побить
        //DontDestroyOnLoadLevel.load.healthPoints = Health;
    }

    public override int Health { get; set; } = 10;
    public override float PredatorSpeed { get; } = 10;

    public override int Damage { get; } = 5;

    public override int LootMeat { get; } = 0;

    public override void Attack()
    {
       if(Health != 0)
        {
            Health--;
        }
    }

    private void OnEnable()
    {
        if(Health != 10)
        Health = DontDestroyOnLoadLevel.load.healthPoints;
    }
    //Временное решение для теста
    private void OnDestroy()
    {
        DontDestroyOnLoadLevel.load.healthPoints = Health;
    }
    
}
