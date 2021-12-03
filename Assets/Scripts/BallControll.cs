using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{
    //[SerializeField] private GameObject scriptableObject;

    private int speedBall;
    private bool isPressedButtonUp = false;

    public bool IsPressedButtonUp
    {
        get{ return isPressedButtonUp; }
        set { isPressedButtonUp = value;}
    }
    public int SpeedBall
    {
        get { return speedBall; }
        set { speedBall = value; }
    }

    private Rigidbody2D ballRigidbody;

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!transform.parent.GetComponent<GameManager>().GameOver)
        {
            if (IsPressedButtonUp)
            {
                ballRigidbody.velocity = Vector3.up * speedBall;
            }
            else
            {
                ballRigidbody.velocity = Vector3.up * -speedBall;
            }
        }
    }
}
