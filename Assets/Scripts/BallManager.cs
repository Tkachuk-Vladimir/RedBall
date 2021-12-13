using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [Tooltip("Reference on ball prefab")]
    [SerializeField] private GameObject ballPrefab;

    //Словарь для ball на сцене
    public static Dictionary<GameObject, BallControll> Ball;
    private Queue<GameObject> currentBall;

    // Instantiate Ball  
    private void Start()
    {
        Ball = new Dictionary<GameObject, BallControll>();
        currentBall = new Queue<GameObject>();

        // Instantiate Ball  
        var ballprefab = Instantiate(ballPrefab);
        var script = ballprefab.GetComponent<BallControll>();

        Ball.Add(ballprefab, script); //Add in dictionary
        currentBall.Enqueue(ballprefab); //Add in queue

        ballprefab.transform.parent = transform; //make how child object BallManager
        ballprefab.SetActive(true);
        // set speedBall settingt
        //newScript.Init(ballSpeed);

        BallControll.OnBallOver += ReturnObstacle;
    }
    //Acive Ball
    public void StartGame()
    {
        var ballInScene = currentBall.Dequeue();
        //var ballInScene = Ball.Values.
        var script = Ball[ballInScene];
        ballInScene.SetActive(true);

        script.FlyToDown();
        // gameObject.transform.GetChild(0).GetComponents<BallControll>().

        currentBall.Enqueue(ballInScene); //Add in queue 
    }
    
    //Set Setting ball
    public void SetLevelSettings(DifficultyLevelData levelSettings)
    {
        var ballInScene = currentBall.Dequeue();
        var script = Ball[ballInScene];
        script.Init(levelSettings);
        currentBall.Enqueue(ballInScene); //Add in queue
        //script.AddInQueue();// Обратно в очередь
    }
    //Возврат ball обратно в пул, подготовка к следующему повтору
    private void ReturnObstacle(GameObject _ball)
    {
        //_ball.transform.position = transform.position;
        //_ball.SetActive(false);
        currentBall.Enqueue(_ball);
    }
}
