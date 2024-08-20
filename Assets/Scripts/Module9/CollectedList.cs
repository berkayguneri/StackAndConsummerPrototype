using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectedList : MonoBehaviour
{
    public static CollectedList instance;

    public List<GameObject> inventory = new List<GameObject>();
    public Transform player;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Follow();
    }

    public void Stack(GameObject obj, int index)
    {
        obj.transform.parent = player;
        Vector3 newPos = inventory[index].transform.localPosition;

        if (inventory[index].CompareTag("Player"))
        {
            newPos += new Vector3(0, 1, 2);
        }
        else
        {
            newPos.z += 1;
        }

        obj.transform.localPosition = newPos;
        inventory.Add(obj);
        StartCoroutine(CubeScale());
    }

    public void Follow()
    {
        for (int i = 1; i < inventory.Count; i++)
        {
            if (inventory[i].transform.localPosition != null)
            {
                Vector3 pos = inventory[i].transform.localPosition;
                pos.x = inventory[i - 1].transform.localPosition.x;
                inventory[i].transform.DOLocalMove(pos, 0.1f);
            }
        }
    }

    public IEnumerator CubeScale()
    {
        for (int i = inventory.Count - 1; i >= 1; i--)
        {
            int index = i;
            Vector3 originalScale = new Vector3(1.6f, 0.5f, 0.5f); // Küpün orijinal ölçek deðeri
            Vector3 scaledUp = originalScale * 1.2f; // Geçici büyütme

            // Küpü biraz büyüt ve sonra tekrar orijinal boyutuna küçült
            inventory[index].transform.DOScale(scaledUp, 0.05f).OnComplete(() => inventory[index].transform.DOScale(originalScale, 0.05f));
            yield return new WaitForSeconds(0.03f);
        }
    }

}
