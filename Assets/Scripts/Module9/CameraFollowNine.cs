using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowNine : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
