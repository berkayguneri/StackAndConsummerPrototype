using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishContr : MonoBehaviour
{
    public Camera mainCamera;
    public Camera finisCamera;
    public FinalMoney fmc;
    public GameObject dublör;
    private bool once = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("conveyor") && !once)
        {
            if (GetComponent<CollectedList>().inventory.Count == 1)
            {
                StartCoroutine(NewCamera());
            }

            once = true;
        }
    }

    public IEnumerator NewCamera()
    {
        yield return new WaitForSeconds(2);
        finisCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);

        foreach (GameObject item in fmc.finalCollectable)
        {
            item.SetActive(true);
        }

        dublör.SetActive(true);
    }
}
