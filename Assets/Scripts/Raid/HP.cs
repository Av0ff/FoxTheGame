using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    private Slider _hp;

    private Predator _predator;

    private void Awake()
    {
        _hp = gameObject.GetComponent<Slider>();
        _predator = gameObject.GetComponentInParent<Predator>();
        _hp.maxValue = _predator.Health;
        if (_predator is Fox) _hp.value = DontDestroyOnLoadLevel.Load.HealthPoints;
    }

    private void Update()
    {
        _hp.value = _predator.Health;
    }
}
