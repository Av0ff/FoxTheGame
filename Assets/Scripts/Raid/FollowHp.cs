using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHp : MonoBehaviour
{
    private Camera cameraM;
    void Start()
    {
        cameraM = Camera.main;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cameraM.transform.forward);
    }
}
