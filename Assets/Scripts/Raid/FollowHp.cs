using UnityEngine;

public class FollowHp : MonoBehaviour
{
    private Camera _cameraM;
    void Start()
    {
        _cameraM = Camera.main;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + _cameraM.transform.forward);
    }
}
