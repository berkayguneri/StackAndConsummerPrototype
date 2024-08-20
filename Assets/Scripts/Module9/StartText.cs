using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    public Animator playerAnim;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameManagerNine.instance.isGameStart = true;
            playerAnim.SetTrigger("walking");
            gameObject.SetActive(false);
        }
    }
}
