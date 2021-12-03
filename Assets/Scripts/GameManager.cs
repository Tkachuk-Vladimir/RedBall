using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //UI
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject indicatorTapToPlay;
    [SerializeField] private GameObject upButton;

    [SerializeField] private GameObject lineConstraint;
    [SerializeField] private GameObject scriptableObject;
    [SerializeField] private GameObject ball;
    [SerializeField] private Text textDurationLastAttempt;
    [SerializeField] private Text textAttemptCounter;

    private int attemptCounter = 0;
    private bool onePlusAttemptCounter;

    private float durationLastAttempt;
    private float timerCurrentAttempt;

   
    private float xPosCreateLine = -6.3f;
    private float yPosCreateLine = 4.61f;
    private bool gameOver;

    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }
    

    void Start()
    {
        gameOver = true;
        onePlusAttemptCounter = false;

        CreateLineConstraint();

        startMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        indicatorTapToPlay.SetActive(false);
        upButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CountingDurationLastAttempt();
        PrintAttemptCounter();

    }

    public void SwitchGameOverFalse()
    {
        if (gameOver)
        {
            gameOver = false;
            indicatorTapToPlay.SetActive(false);
        }
    }

    public void StartGame()
    {

       // gameOver = false;

        //ui
        startMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        indicatorTapToPlay.SetActive(true);
        upButton.SetActive(true);

        // creat ball object how child 
        var newBall = Instantiate(ball, new Vector2(-5f, 1.8f), Quaternion.identity);

        // add as child object
        newBall.transform.parent = gameObject.transform;

        //set speed ball
        newBall.GetComponent<BallControll>().SpeedBall = scriptableObject.GetComponent<ScriptableObject>().SetSpeedBall;

        //set spawn rate
        transform.GetChild(0).GetComponent<ObstaclePoolControll>().SpawnRate = scriptableObject.GetComponent<ScriptableObject>().SetSpawnRate;

    }

    public void DestroyBall()
    {
        //destroy ball
        Destroy(transform.GetChild(13).gameObject);

        //ui
        // active gameOver menu
        gameOverMenu.SetActive(true);
        startMenu.SetActive(false);
        indicatorTapToPlay.SetActive(true);
        upButton.SetActive(true);

    }

    // Button controll
    public void UpBall(bool isPressed)
    {
        if (!gameOver)
        {
            gameObject.transform.GetChild(13).GetComponent<BallControll>().IsPressedButtonUp = isPressed;
        }
    }

    private void CreateLineConstraint()
    {
        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < 6; i++)
            {
                var newline = Instantiate(lineConstraint, new Vector2(xPosCreateLine, yPosCreateLine), Quaternion.identity);
               // newline = new GameObject("Line " + i);
                newline.transform.parent = gameObject.transform;

                xPosCreateLine = xPosCreateLine + 5.76f;
            }
            xPosCreateLine = -6.3f;
            yPosCreateLine = -2.24f;
        }
        xPosCreateLine = -6.3f;
    }

    private void CountingDurationLastAttempt()
    {
        if (gameOver)
        {
            textDurationLastAttempt.text = "Duration of the last attempt :  " + durationLastAttempt.ToString() + " s";

            timerCurrentAttempt = 0;
            // durationLastAttempt = 0;
        }
        else
        {
            timerCurrentAttempt += Time.deltaTime;

            durationLastAttempt = Mathf.Round(timerCurrentAttempt * 10.0f) * 0.1f;

        }
    }
    public void PrintAttemptCounter()
    {
        if (gameOver)
        {
            if (onePlusAttemptCounter)
            {
                attemptCounter++;
                textAttemptCounter.text = "Attempt counter :  " + attemptCounter.ToString();
                onePlusAttemptCounter = false;
            }
        }
        else
        {
            onePlusAttemptCounter = true;
        }
    }
    public void ChangeDifficulty()
    {
        startMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }
}
