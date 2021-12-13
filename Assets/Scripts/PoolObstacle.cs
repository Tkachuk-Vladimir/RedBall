using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObstacle : PoolCreate
{
    [Tooltip("Count of obstacles in the pool")]
    [SerializeField] private int poolObstaclesCount;
    
    [Tooltip("Reference on obstacles prefab")]
    [SerializeField] private GameObject obstaclesPrefab;


    [SerializeField] private float addSpeed;
    [SerializeField] private float startSpeed;
    [SerializeField] private float frequencyAddSpeed;

    private float frequencySpawn;
    private float speedObstacle = 0;

    private Coroutine spawnRoutine;
    private Coroutine addSpeedObstacleRoutine;

    //Словарь для скриптов препятствий на сцене
    public static Dictionary<GameObject, ObstacleControll> poolObstacles;
    private Queue<GameObject> currentObstacles;

    private void Start()
    {
        CreatePool();
    }

    //Set Settings
    public void SetLevelSettings(DifficultyLevelData levelSettings)
    {
       // Set frequency
       frequencySpawn = levelSettings.FrequencySpawn;
       Debug.Log("frequency: " + levelSettings.FrequencySpawn);
    }

    public override void StartGame()
    {
        spawnRoutine = StartCoroutine(Spawn());
        addSpeedObstacleRoutine = StartCoroutine(AddSpeedObstacle());

        speedObstacle = startSpeed;

        //InvokeRepeating("IncreaseSpeed", 0f, frequencyAddSpeed);
    }

    public override void StopGame()
    {
        StopCoroutine(spawnRoutine); // остановка coroutine spawn()
        StopCoroutine(addSpeedObstacleRoutine); // остановка coroutine AddSpeedObstacle()

        speedObstacle = startSpeed;

        // 
        foreach (var obstacleInPool in poolObstacles)
        {
            //obstacleInPool.Value.SpeedObstacle = 0; // обнуляем скорость 
            obstacleInPool.Key.SetActive(false);
           // currentObstacles.Enqueue(obstacleInPool.Key);
        }
    }

    public override void CreatePool()
    {
        poolObstacles = new Dictionary<GameObject, ObstacleControll>();
        currentObstacles = new Queue<GameObject>();

        // Instantiate pool Obsticale 
        for (int i = 0; i < poolObstaclesCount; i++)
        {
            var prefab = Instantiate(obstaclesPrefab);
            var script = prefab.GetComponent<ObstacleControll>();
            prefab.SetActive(false);
            prefab.transform.parent = transform; //make how child object PoolObject
            poolObstacles.Add(prefab, script);
            currentObstacles.Enqueue(prefab);
        }
       ObstacleControll.OnObstacleOver += ReturnObstacle;
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            /*
            foreach (var obstacleInPool in poolObstacles)
            {
                yield return new WaitForSeconds(frequencySpawn);
                // получение компанентов и активация препятствия
                float yPos = Random.Range(-1.8f, 3f); //Генерация случайного места появления по высоте Y
                obstacleInPool.Key.transform.position = new Vector2(transform.position.x, yPos);
                obstacleInPool.Key.SetActive(true);
                obstacleInPool.Value.SpeedObstacle = speedObstacle; // set curren speed 
            }
            */
            
            yield return new WaitForSeconds(frequencySpawn);
            
            if (currentObstacles.Count > 0)
            {
                // получение компанентов и активация препятствия
                var obstacle = currentObstacles.Dequeue();
                var script = poolObstacles[obstacle]; // get obstacle script
                script.SpeedObstacle = speedObstacle; // set curren speed
                float yPos = Random.Range(-1.8f, 2.7f); //Генерация случайного места появления по высоте Y
                obstacle.transform.position = new Vector2(transform.position.x, yPos);
                obstacle.SetActive(true);
            }
        }
    }
    
    private IEnumerator AddSpeedObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(frequencyAddSpeed);

            speedObstacle += addSpeed;
            Debug.Log("seedObs :" + speedObstacle);

            foreach (var obstacleInPool in poolObstacles)
            {
             obstacleInPool.Value.SpeedObstacle = speedObstacle; // добавлям скорость
            }
        }
    }

   //Возврат препятствий обратно в очередь, подготовка к следующему повтору
    private void ReturnObstacle(GameObject obstacleOut)
    {
        obstacleOut.transform.position = transform.position;
        obstacleOut.SetActive(false);
        currentObstacles.Enqueue(obstacleOut);
    }
  
}
