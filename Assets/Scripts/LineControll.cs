using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControll : MonoBehaviour
{
   // [SerializeField] private float addSpeed;
   // private float startSpeedLine = 0;
    //[SerializeField] private bool gameСondition = false;

    [SerializeField] private float speedLine;

    public float SpeedLine
    {
        get { return speedLine; }
        set { speedLine = value; }
    }
    /*
    public void StartGame()
    {
        if (!gameСondition)
        {
          InvokeRepeating("IncreaseSpeed", 0f, 2f);

          //set start speed
          //speedLine = startSpeedLine;

          gameСondition = true;
        }   
    }
    */

    void LateUpdate()
    {
      //movoment line
      transform.Translate(Vector3.right * -speedLine * Time.deltaTime);  
    }

    /*
    private void IncreaseSpeed()
    {
        speedLine += addSpeed;
    }
    */
}
