using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField]
    private Fox _fox;
    
    private void Update()
    {
        gameObject.GetComponentInChildren<Slider>().value = _fox.Health;
    }
}
