using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<Slider>().value = DontDestroyOnLoadLevel.load.healthPoints;
    }
}
