using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesNine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("conveyor"))
        {
            CollectedList.instance.inventory.Remove(gameObject);
            ObstacleObject.instance.ScoreUpdate();
            Destroy(gameObject);
        }
    }
}
