using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    public static ObstacleObject instance;
    public int score;
    [SerializeField] public TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance= this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collected"))
        {
            //ScoreUpdate();

            //CollectedList.instance.inventory.Remove(other.gameObject);
            //Destroy(other.gameObject);



            //if (CollectedList.instance.inventory.Count - 1 == CollectedList.instance.inventory.IndexOf(other.gameObject)) //listenin son elemaný ise
            //{
            //    Debug.LogWarning("ghirdi");
            //    CollectedList.instance.inventory.Remove(other.gameObject);
            //    Destroy(other.gameObject);
            //    ScoreUpdate();
            //}

            GameObject lastCollected = CollectedList.instance.inventory[CollectedList.instance.inventory.Count - 1];

            // Son elemaný listeden kaldýr ve yok et
            CollectedList.instance.inventory.Remove(lastCollected);
            Destroy(lastCollected);
            ScoreUpdate();

        }
        else if (other.CompareTag("Player") && CollectedList.instance.inventory.Count  < 2)
        {
            GameManagerNine.instance.LosePanelActive();
            PlayerControllerNine.instance.canMove = false;
            PlayerControllerNine.instance.anim.SetTrigger("idle");
        }
    }


    public void ScoreUpdate()
    {
        score++;
        scoreText.text = score.ToString();
        
    }
}
