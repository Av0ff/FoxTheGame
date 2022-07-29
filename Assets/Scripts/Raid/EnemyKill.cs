using System;
public class EnemyKill
{
    public event Action OnEnemyKilled;

    public void SendEnemyKilled()
    {
        OnEnemyKilled.Invoke();
    }
}
