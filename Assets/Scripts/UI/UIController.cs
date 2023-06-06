using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public PlayerController playerController;
    public ImageBar healthBar;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text coinText;

    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    public Fade fade;
    private MusicManager musicManager;

    [SerializeField] private GameObject panels;

    private void Update()
    {
        if (panels != null && Input.GetKeyDown(KeyCode.Escape))
        {          
            for (int i = 0; i < panels.transform.childCount; i++)
            {
                if (panels.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    panels.transform.GetChild(i).gameObject.SetActive(false);
                    Time.timeScale = 1f;
                }
                else if (panels.transform.GetChild(i).gameObject.tag == "Pause" && losePanel.gameObject.activeInHierarchy == false && winPanel.gameObject.activeInHierarchy == false)
                {
                    panels.transform.GetChild(i).gameObject.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
            
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
        playerController.OnRecountedCoins += PlayerController_OnRecountedCoins;
        playerController.OnRecountedScore += PlayerController_OnRecountedScore;
        musicManager = GameObject.FindGameObjectWithTag("Music").gameObject.GetComponent<MusicManager>();
        fade.FadeWhite();
    }

    private void PlayerController_OnRecountedScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    private void PlayerController_OnRecountedCoins(int coins)
    {
        coinText.text = coins.ToString();
    }

    public void LoadLevel(int buildIndex)
    {
        fade.currentIndexScene = buildIndex;
        fade.FadeBlack();
    }
    public void ChangeTimeScale(int timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void Lose()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
        playerController.enabled = false;
        playerController.ZeroPhysic();
    }
    public void Win()
    {
        Time.timeScale = 0f;
        winPanel.SetActive(true);
        playerController.enabled = false;
        playerController.ZeroPhysic();
    }

    public void SetActiveUI(GameObject gameObject)
    {
        if (gameObject.activeInHierarchy == false)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
