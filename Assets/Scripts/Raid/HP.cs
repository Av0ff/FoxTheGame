using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    private Slider hp;
    private Predator predator;
    private void Awake()
    {
        hp = gameObject.GetComponent<Slider>();
        predator = gameObject.GetComponentInParent<Predator>();
        hp.maxValue = predator.Health;
        if (predator is Fox) hp.value = DontDestroyOnLoadLevel.load.healthPoints;
    }

    private void Update()
    {
        hp.value = predator.Health;
    }
}
