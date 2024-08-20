using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collectable"))
        {
            if (!CollectedList.instance.inventory.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "collected";
                other.gameObject.GetComponent<Collect>().enabled = true;
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                CollectedList.instance.Stack(other.gameObject, CollectedList.instance.inventory.Count - 1);
            }
        }
        
    }
}
