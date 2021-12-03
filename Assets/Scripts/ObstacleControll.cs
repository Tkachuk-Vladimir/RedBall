using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControll : MonoBehaviour
{
    [SerializeField] private float startSpeedObstacle;
    [SerializeField] private float addSpeed;
    [SerializeField] private float timerIncreaseSpeed;
    [SerializeField] private float timer;

    private float speedObstacle;
    private bool setCombatPosition;

    public bool SetCombatPosition
    {
        get { return setCombatPosition; }
        set { setCombatPosition = value; }
    }

    private void Start()
    {
        //set start speed
        speedObstacle = startSpeedObstacle;

        setCombatPosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.transform.parent.GetComponent<GameManager>().GameOver)
        {
            //set start speed
            speedObstacle = startSpeedObstacle;

            timer = 0;
        }
        else
        {
            // Increase speed ewery N second;
            IncreaseSpeed();

            //movoment obstacle if setCombatPosition
            MovementObsacle();
        }
    }
    private void MovementObsacle()
    {
        if (setCombatPosition)
        {
            transform.Translate(Vector3.right * -speedObstacle * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // switch gameOver
            transform.parent.transform.parent.GetComponent<GameManager>().GameOver = true;
            // destroy ball
            transform.parent.transform.parent.GetComponent<GameManager>().DestroyBall();
        }
    }
    private void IncreaseSpeed()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer >= timerIncreaseSpeed)
        {
            speedObstacle += addSpeed;
            timer = 0f;
            //Debug.Log(speedLine);
        }
    }
}
