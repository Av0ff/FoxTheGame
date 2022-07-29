using UnityEngine;

public class LootSystem : MonoBehaviour
{
    [SerializeField]
    private Fox _character;

    private DontDestroyOnLoadLevel _data = DontDestroyOnLoadLevel.Load;

    private void Awake()
    {
        _character = GameObject.FindObjectOfType<Fox>();
        gameObject.GetComponent<Outline>().OutlineWidth = 0;
    }

    private void Update()
    {
        if(_data.Food != 9)
        {
            if (DistanceToPickUp() < 3f)
            {
                _data.Food++;
                Destroy(gameObject);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _character.transform.position, Time.deltaTime * 10f);
            }
        }
    }

    private float DistanceToPickUp()
    {
        Vector3 direction = _character.transform.position - transform.position;

        return Vector3.Magnitude(direction);
    }
}
