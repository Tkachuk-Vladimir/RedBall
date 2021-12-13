using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Difficult Level", menuName = "Level/Difficulty Level Data", order = 1)]
public class DifficultyLevelData : ScriptableObject
{
    [Tooltip("Obstacle frequency spawn")]
    [SerializeField] private float frequencySpawn;

    [Tooltip("Speed Ball")]
    [SerializeField] private float ballSpeed;

    public float FrequencySpawn
    {
        get { return frequencySpawn; }
        protected set { }
    }
    public float BallSpeed
    {
        get { return ballSpeed; }
        protected set { }
    }
}
