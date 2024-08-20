using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerControllerNine : MonoBehaviour
{
    public static PlayerControllerNine instance;
    [HideInInspector] public Animator anim;
    private Vector3 firstTouchPosition;
    [HideInInspector] public Vector3 curTouchPosition;
    [SerializeField] private float sensitivityMultiplier = 0.01f;
    private float finalTouchX;
    private float xBound = 4f;
    [HideInInspector] public bool canMove = true;
    private void Awake()
    {
        anim = GetComponent<Animator>();

        instance = this;
    }

    void Update()
    {
        if (canMove && GameManagerNine.instance.isGameStart)
        {
            Move();
        }
    }

    public void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            curTouchPosition = Input.mousePosition;

            Vector2 touchDelta = (curTouchPosition - firstTouchPosition);

            finalTouchX = (transform.position.x + (touchDelta.x * sensitivityMultiplier));
            finalTouchX = Mathf.Clamp(finalTouchX, -xBound, xBound);

            transform.position = new Vector3(finalTouchX, transform.position.y, transform.position.z);

            firstTouchPosition = Input.mousePosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("conveyor"))
        {
            anim.SetTrigger("idle");
            canMove = false;
            ForwardController.instance.speed = 0;
        }
    }

    
}
