using UnityEngine;

public class DontDestroyOnLoadLevel : MonoBehaviour
{
    public static DontDestroyOnLoadLevel Load { get; private set; }

    public Fox Fox;

    public int HealthPoints;
    [Tooltip("Не ставить больше 9")]
    [SerializeField]
    private int _food1;

    public int MaxFood { get; } = 9;

    public int Food { get { return _food1; } set { if (value < 10) { _food1 = value; } } }




    private void Awake()
    {
        HealthPoints = Fox.Health;
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
