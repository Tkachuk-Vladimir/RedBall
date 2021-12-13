using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BallControll : MonoBehaviour
{
    //private DifficultyLevelData speedData;
    [SerializeField] private GameEvent OnCollision;


    public static Action<GameObject> OnBallOver;
    //private DifficultyLevelData setSpeedSetting;

    private float speedBall;
    private Rigidbody2D ballRigidbody;
    private Vector2 ballStartPosition = new Vector2(-5f, 1.8f);

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        //FlyToDown();
    }
  
    public void Init(DifficultyLevelData setSpeed)
    {
        speedBall = setSpeed.BallSpeed;

        Debug.Log("speedBall: " + speedBall);
    }

    public void FlyToTop()
    {
        ballRigidbody.velocity = Vector3.up * speedBall;
    }
    public void FlyToDown()
    {
        ballRigidbody.velocity = Vector3.up * -speedBall;
    }
    public void AddInQueue()
    {
        OnBallOver(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        OnCollision.Raise(); // Event from game over

        OnBallOver(gameObject); // в очередь
        gameObject.transform.position = ballStartPosition;
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
