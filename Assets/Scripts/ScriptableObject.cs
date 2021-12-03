using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObject : MonoBehaviour
{
    [SerializeField] private int speedBall;
    [SerializeField] private int easySpeedBall;
    [SerializeField] private int mediumSpeedBall;
    [SerializeField] private int hardSpeedBall;

    [SerializeField] private float spawnRate;
    [SerializeField] private float easySpawnRate;
    [SerializeField] private float mediumSpawnRate;
    [SerializeField] private float hardSpawnRate;

    public int SetSpeedBall
    {
        get { return speedBall; }
        set { speedBall = value; }
    }
    public float SetSpawnRate
    {
        get { return spawnRate; }
        set { spawnRate = value; }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(SetSpeedBall);
    }

    public void EasyButton()
    {
        speedBall = easySpeedBall;
        spawnRate = easySpawnRate;
    }

    public void MediumButton()
    {
        speedBall = mediumSpeedBall;
        spawnRate = mediumSpawnRate;
    }

    public void HardButton()
    {
        speedBall = hardSpeedBall;
        spawnRate = hardSpawnRate;
    }
}
