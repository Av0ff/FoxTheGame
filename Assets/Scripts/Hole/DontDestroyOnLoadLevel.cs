using UnityEngine;

public class DontDestroyOnLoadLevel : MonoBehaviour
{
    [SerializeField]
    private Fox _fox;

    public int HealthPoints;

    [Tooltip("Не ставить больше 9")]
    [SerializeField]
    private int _food1;

    public static DontDestroyOnLoadLevel Load { get; private set; }

    public int MaxFood { get; } = 9;

    public int Food { get { return _food1; } set { if (value < 10) { _food1 = value; } } }

    private void Awake()
    {
        HealthPoints = _fox.Health;
        if (Load == null)
        {
            Load = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Load != this)
        {
            Destroy(gameObject);
        }
    }

}
