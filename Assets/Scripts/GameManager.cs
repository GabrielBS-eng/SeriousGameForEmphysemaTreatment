using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;

    public static GameManager Instance;

    public GameObject startPage;
    public GameObject gameOverPage;
    public GameObject countdownPage;
    public Text scoreText;

    public GameObject player;
    public GameObject barAndCount;

    public enum PageState
    {
        None,
        Start,
        GameOver,
        Countdown
    }

    //int score = 0;
    bool gameOver;

    public bool GameOver { get { return gameOver; } }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if(PressController.gameOver)
        {
            OnPlayerDied();
        }
    }

    void OnEnable()
    {
        CountdownText.OnCountdownFinished += OnCountdownFinished;
        //PressController.OnPlayerDied += OnPlayerDied;
    }

    void OnDisable()
    {
        CountdownText.OnCountdownFinished -= OnCountdownFinished;
        //PressController.OnPlayerDied -= OnPlayerDied;
    }

    void OnCountdownFinished()
    {
        SetPageState(PageState.None);
        OnGameStarted();
        //score = 0;
        gameOver = false; 
    }

    void OnPlayerDied()
    {
        //int savedScore = PlayerPrefs.GetInt("HighScore");
        //if (score > savedScore)
        //{
        //    PlayerPrefs.SetInt("HighScore", score);
        //}
        //this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z), 3*Time.deltaTime);
        //transform.position = new Vector3(transform.position.x, transform.position.y+5f, transform.position.z);
        SetPageState(PageState.GameOver);
    }

    void SetPageState(PageState state)
    {
        switch (state)
        {
            case PageState.None:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                break;
            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                countdownPage.SetActive(false);
                break;
            case PageState.Countdown:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(true);
                break;
        }

    }

    public void ConfirmGameOver()
    {
        //activated when replay button is hit
        //OnGameOverConfirmed(); //event
        //scoreText.text = "0";
        player.transform.position = new Vector3(-39f, -2.8f, 0);
        player.SetActive(false);
        barAndCount.SetActive(false);
        PressController.state = PressController.gameState.scene;
        PressController.gameOver = false;
        SetPageState(PageState.Start);
    }

    public void Quit()
    {
        PressController.gameOver = false;
        Application.Quit();
    }

    public void StartGame()
    {
        if (float.Parse(Parameters.countDown) > 0)
        {
            //activated when play button is hit
            SetPageState(PageState.Countdown);
            player.SetActive(true);
            barAndCount.SetActive(true);
        }
    }
}
