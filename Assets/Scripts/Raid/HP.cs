using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    private Slider hp;
    private Fox fox;
    private void Awake()
    {
        hp = gameObject.GetComponent<Slider>();
        fox = gameObject.GetComponentInParent<Fox>();
        hp.value = DontDestroyOnLoadLevel.load.healthPoints;
    }

    private void Update()
    {
        hp.value = fox.Health;
    }
}
