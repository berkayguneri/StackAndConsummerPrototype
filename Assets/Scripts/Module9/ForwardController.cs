using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardController : MonoBehaviour
{
    public static ForwardController instance;

    public float speed;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if (GameManagerNine.instance.isGameStart)
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        }
    }
}
