using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameActive = false;

    public Button RestartButton;

    public Button PauseButton;

    public Button ResumeButton;

    public Button StartButton;

    public GameObject ScoreUI;

    public GameObject title1;

    public GameObject title2;

    public Text scoreNumberText;

    public Text LevelText;

    public GameObject ScoreText;

    public GameObject Level_Text;

    public GameObject LevelNumberText;

    public Text BestScoreNumber;

    public Text BestScoreText;

    public GameObject Board;

    private void Awake()
    {
        Instance = this;
        
    }

    void Start()
    {
        isGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        isGameActive = true;

        Board.gameObject.SetActive(true);

        StartButton.gameObject.SetActive(false);

        RestartButton.gameObject.SetActive(true);

        PauseButton.gameObject.SetActive(true);

        ResumeButton.gameObject.SetActive(false);

        ScoreUI.gameObject.SetActive(true);

        title1.gameObject.SetActive(false);

        title2.gameObject.SetActive(true);

        ScoreText.gameObject.SetActive(true);

        Level_Text.gameObject.SetActive(true);

        scoreNumberText.gameObject.SetActive(true);

        LevelNumberText.gameObject.SetActive(true);

        BestScoreNumber.gameObject.SetActive(true);

        BestScoreText.gameObject.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        ResumeButton.gameObject.SetActive(true);
        PauseButton.gameObject.SetActive(false);

        Time.timeScale = 0;

    }

    public void ResumeGame()
    {
        ResumeButton.gameObject.SetActive(false);
        PauseButton.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

}
