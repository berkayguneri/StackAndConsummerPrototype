using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerNine : MonoBehaviour
{
    public static GameManagerNine instance;

    public GameObject finishPanel;
    public GameObject losePanel;
    [HideInInspector] public bool isGameStart = false;
    [HideInInspector] public bool isGameFinish = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (isGameFinish)
        {
            Invoke(nameof(FinishPanelActive), 2);
        }
    }

    public void FinishPanelActive()
    {
        finishPanel.SetActive(true);
    }
    public void LosePanelActive()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
