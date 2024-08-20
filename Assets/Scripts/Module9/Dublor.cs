using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Dublor : MonoBehaviour
{
    public FinishCam finishCam;
    private void Start()
    {
        transform.DOMove(new Vector3(0, 0.7f, 170), 1);
        transform.DORotate(new Vector3(0, 180, 0), 1).OnComplete(() => finishCam.target = transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("rankscbe"))
        {
            other.transform.DOMoveZ(other.transform.position.z - 1, 0.5f);
            Debug.Log("degiyor");
        }
    }

}
