using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameplayManager : MonoBehaviour
{
    private int score;
    private int highScore;
    private bool gameRunning;
    private Vector2 leftPaddlePos;
    private Vector2 rightPaddlePos;
    private Vector2 ballPos;

    [Header("UI")]
    [SerializeField] private TMP_Text txt_score;
    [SerializeField] private TMP_Text txt_highScore;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private TMP_Text CountdownTimer;

    [Header("GameObjects")]
    [SerializeField] private Transform leftPaddle;
    [SerializeField] private Transform RightPaddle;
    [SerializeField] private Transform ball;

    public static UnityAction Evnt_StartGame;

    private void Awake()
    {
        score = 0;
        highScore = 0;
        txt_score.text = score + ""; 
        MenuPanel.SetActive(true);
        CountdownTimer.text = "";
        gameRunning = false;

        leftPaddlePos = leftPaddle.position;
        rightPaddlePos = RightPaddle.position;
        ballPos = ball.position;

        InitHighScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameRunning)
        {
            StartCountdown();
        }
    }

    private void StartCountdown()
    {
        StartCoroutine(StartGame());
    }
    private IEnumerator StartGame()
    {
        MenuPanel.SetActive(false);

        CountdownTimer.text = "3";
        yield return new WaitForSeconds(1);
        CountdownTimer.text = "2";
        yield return new WaitForSeconds(1);
        CountdownTimer.text = "1";
        yield return new WaitForSeconds(1);
        CountdownTimer.text = "";

        gameRunning = true;
        Evnt_StartGame?.Invoke();
    }

    private void Score()
    {
        score++;
        txt_score.text = score + "";
    }

    private void GameOver()
    {
        if (score > highScore) SetHighScore(score);

        leftPaddle.position = leftPaddlePos;
        RightPaddle.position = rightPaddlePos;
        ball.position = ballPos;

        gameRunning = false;
        MenuPanel.SetActive(true);
        score = 0;
        txt_score.text = score + "";
    }

    private void InitHighScore()
    {
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", highScore);
        }
        else
        {
            highScore = PlayerPrefs.GetInt("Highscore");
        }
        txt_highScore.text = highScore + "";
    }

    private void SetHighScore(int score)
    {
        highScore = score;
        PlayerPrefs.SetInt("Highscore", highScore);
        txt_highScore.text = highScore + "";
    }

    private void OnEnable()
    {
        Ball.Evnt_Score += Score;
        Ball.Evnt_GameOver += GameOver;
    }
    private void OnDisable()
    {
        Ball.Evnt_Score -= Score;
        Ball.Evnt_GameOver -= GameOver;
    }

}
