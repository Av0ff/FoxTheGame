using UnityEngine;

public class MeatManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _meat;

    [SerializeField]
    private GameObject[] _foodPlace = new GameObject[9];

    private DontDestroyOnLoadLevel _data;

    private void Start()
    {
        _data = DontDestroyOnLoadLevel.Load;
        if (_data.Food != 0)
        {
            for (int i = 0; i < _data.Food; i++)
            {
                Instantiate(_meat, _foodPlace[i].transform.position, Quaternion.identity, _foodPlace[i].transform);
            }
        }
    }

    private void OnEnable()
    {
        _meat.GetComponent<LootSystem>().enabled = false;
        _meat.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnDestroy()
    {
        _meat.GetComponent<LootSystem>().enabled = true;
        _meat.GetComponent<Rigidbody>().isKinematic = false;
    }

}
