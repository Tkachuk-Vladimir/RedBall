using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleControll : MonoBehaviour
{
    private float speedObstacle;
    public static Action<GameObject> OnObstacleOver;

    public float SpeedObstacle
    {
        get { return speedObstacle; }
        set { speedObstacle = value; }
    }

    void Update()
    {
        //movoment obstacle if setCombatPosition
        MovementObsacle();

        // когда выходит за предел камеры,с помощью события запрашиваем возврат на обратно в пул
        if(transform.position.x < -10 && OnObstacleOver != null)
        //if (transform.position.x < -10)
        {
            OnObstacleOver(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void MovementObsacle()
    {
       transform.Translate(Vector3.right * -speedObstacle * Time.deltaTime);
    }
}
