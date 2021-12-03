using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePoolControll : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int obstaclePoolSize = 5;
    [SerializeField] private float obstacleMinPosition;
    [SerializeField] private float obstacleMaxPosition;
    private float spawnRate = 7f;

    private GameObject[] obstacle;
    private Vector2 objectPoolPosition = new Vector2(0f, -6f);
    private float timeLastSpawned = 0f;
    private float spawnXPosition = 10f;
    private int currentObstacle = 0;

    public float SpawnRate
    {
        get { return spawnRate; }
        set { spawnRate = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        obstacle = new GameObject[obstaclePoolSize];
        for (int i = 0; i < obstaclePoolSize; i++)
        {
            obstacle[i] = (GameObject)Instantiate(obstaclePrefab, objectPoolPosition, Quaternion.identity);
            obstacle[i].transform.parent = gameObject.transform;
        }
    }
    private void Update()
    {
        if (transform.parent.GetComponent<GameManager>().GameOver)
        {
            currentObstacle = 0;
            timeLastSpawned = 0f;

            RepositionAllPoolObstacle();
        }
        else
        {
            RateObstacle();
        }
    }

    private void RateObstacle()
    {
        timeLastSpawned += Time.deltaTime;

        if (transform.parent.GetComponent<GameManager>().GameOver == false && timeLastSpawned >= spawnRate)
        {
            timeLastSpawned = 0f;
            float spawnYPosition = Random.Range(obstacleMinPosition, obstacleMaxPosition);
            obstacle[currentObstacle].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            obstacle[currentObstacle].transform.GetComponent<ObstacleControll>().SetCombatPosition = true;
            currentObstacle++;
            if (currentObstacle >= obstaclePoolSize)
            {
                currentObstacle = 0;
            }
        }
    }

    private void RepositionAllPoolObstacle()
    {
        for (int i = 0; i < obstaclePoolSize; i++)
        {
            obstacle[i].transform.position = objectPoolPosition;
            obstacle[i].transform.GetComponent<ObstacleControll>().SetCombatPosition = false;
        }
    }
}
