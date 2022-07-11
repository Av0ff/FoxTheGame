using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<Outline>().OutlineWidth = 0;
    }
}
