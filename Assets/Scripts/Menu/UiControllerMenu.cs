using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiControllerMenu : MonoBehaviour
{
    [SerializeField] private GameObject panels;
    [SerializeField] private Fade fade;

    private void Start()
    {
        fade.FadeWhite();
    }

    private void Update()
    {
        if (panels != null && Input.GetKeyDown(KeyCode.Escape))
        {
            for (int i = 0; i < panels.transform.childCount; i++)
            {
                if (panels.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    panels.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }

    public void ChangeActivePanel(GameObject panel)
    {
        if (panel.activeInHierarchy)
            panel.SetActive(false);
        else
            panel.SetActive(true);
    }
    public void ChangeTimeScale(int timeScale)
    {
        Time.timeScale = timeScale;
    }
    public void LoadLevel(int buildIndex)
    {
        fade.currentIndexScene = buildIndex;
        fade.FadeBlack();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
