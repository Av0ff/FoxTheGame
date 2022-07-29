public class Fox : Predator
{
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
        GetComponent<CharacterInteraction>().enabled = false;
    }

    private void OnEnable()
    {
        Health = DontDestroyOnLoadLevel.Load.HealthPoints;
    }

    private void OnDestroy()
    {
        DontDestroyOnLoadLevel.Load.HealthPoints = Health;
    }
    
}