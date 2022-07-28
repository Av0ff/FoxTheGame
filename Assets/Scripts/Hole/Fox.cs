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
        //�������� �� ����� �������, ��� ��� ����� ������
        //DontDestroyOnLoadLevel.load.healthPoints = Health;
    }

    public override int Health { get; set; } = 10;
    public override float PredatorSpeed { get; } = 25;

    public override int Damage { get; } = 1;

    public override int LootMeat { get; } = 0;

    public override void Attack(Predator predator)
    {
        predator.Health -= Damage;
    }

    public override void Death()
    {
        
    }

    private void OnEnable()
    {
        //if(Health != 10)
        Health = DontDestroyOnLoadLevel.load.healthPoints;
    }
    //��������� ������� ��� �����
    private void OnDestroy()
    {
        DontDestroyOnLoadLevel.load.healthPoints = Health;
        //DontDestroyOnLoadLevel.fox = this;    //
    }
    
}
