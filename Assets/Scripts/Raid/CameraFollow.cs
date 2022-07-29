using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _player.transform.position;
    }
    void LateUpdate()
    { 
        gameObject.transform.position = _player.transform.position + _offset;
    }
}
