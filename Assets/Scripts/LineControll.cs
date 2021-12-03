using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControll : MonoBehaviour
{
    [SerializeField] private float startSpeedLine;
    [SerializeField] private float addSpeed;
    [SerializeField] private float timerIncreaseSpeed;
    private float speedLine;
    private BoxCollider2D lineCollider;
    private Rigidbody2D lineRigidbody;
    private float lineHorizontalLength;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        //set start speed
         speedLine = startSpeedLine;

        //get component
        lineRigidbody = GetComponent<Rigidbody2D>();
        lineCollider = GetComponent<BoxCollider2D>();
        lineHorizontalLength = lineCollider.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetComponent<GameManager>().GameOver)
        {
            speedLine = startSpeedLine;
            timer = 0;
        }
        else
        {
            // Increase speed ewery N second;
            IncreaseSpeed();

            //movoment line
            //lineRigidbody.velocity = Vector3.right * -speedLine;
            transform.Translate(Vector3.right * -speedLine * Time.deltaTime);
        }
        
    
        if (transform.position.x < -lineHorizontalLength * 2.2f)
        {
            RepositionBackground();
        }
       
    }

    private void RepositionBackground()
    {
        Vector2 lineOffSet = new Vector2(lineHorizontalLength * 5f, 0);
        transform.position = (Vector2)transform.position + lineOffSet;
    }

    private void IncreaseSpeed()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if(timer >= timerIncreaseSpeed)
        {
            speedLine += addSpeed;
            timer = 0f;
            //Debug.Log(speedLine);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Collision the ball");
            transform.parent.GetComponent<GameManager>().GameOver = true;
            transform.parent.GetComponent<GameManager>().DestroyBall();
        }
    }

}
