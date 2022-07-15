 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    public Fox fox;
    
    public void PanelOn()
    {
        gameObject.SetActive(true);
    }

    public void PanelOff()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        gameObject.GetComponentInChildren<Slider>().value = fox.Health;
    }
}
