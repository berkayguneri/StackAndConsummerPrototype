using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMoney : MonoBehaviour
{
    public GameObject collectable;
    public List<GameObject> finalCollectable = new List<GameObject>();

    private void Start()
    {
        for (int i = 1; i < 101; i++)
        {
            GameObject obj = Instantiate(collectable, transform.position - new Vector3(0, i * .4f, 0), Quaternion.identity, transform);
            finalCollectable.Add(obj);
            obj.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dublor"))
        {
            StartCoroutine(Delay());
        }
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.35f);
        transform.DOMoveY(ObstacleObject.instance.score * 4f,  ObstacleObject.instance.score * 0.2f).OnComplete(() => GameManagerNine.instance.isGameFinish = true);
    }
}
