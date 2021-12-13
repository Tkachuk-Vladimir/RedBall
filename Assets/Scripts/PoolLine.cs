using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PoolLine : PoolCreate
{
    [Tooltip("Reference on Line prefab")]
    [SerializeField] private GameObject lineConstraint;

    [SerializeField] private float startSpeed;
    [SerializeField] private float addSpeed;
    [SerializeField] private float frequencyAddSpeed;

    //private float durationLastAttempt;
    //private float timerCurrentAttempt;

    private float xPosCreateLine = -6.3f;
    private float yPosCreateLine = 4.61f;

    public static Dictionary<GameObject, LineControll> poolLines;

    private Coroutine addSpeedLineRoutine;

    void Start()
    {
        CreatePool();
    }

    //Add all obstacle in queue and gameСondition
    public override void StartGame()
    {
        //spawnRoutine = StartCoroutine(Spawn());
        addSpeedLineRoutine = StartCoroutine(AddSpeedLine());

        // set start speed all line
        foreach (var lineInPool in poolLines)
        {
            lineInPool.Value.SpeedLine = startSpeed; // set start speed 
        }
    }

    public override void StopGame()
    {
        StopCoroutine(addSpeedLineRoutine); // остановка coroutine AddSpeedLine()

        // Stop all line
        foreach (var lineInPool in poolLines)
        {
            lineInPool.Value.SpeedLine = 0; // обнуляем скорость 
        }
    }

    public override void CreatePool()
    {
        poolLines = new Dictionary<GameObject, LineControll>();

        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < 6; i++)
            {
                var newLine = Instantiate(lineConstraint, new Vector2(xPosCreateLine, yPosCreateLine), Quaternion.identity);
                var scriptNewLine = newLine.GetComponent<LineControll>();
                poolLines.Add(newLine, scriptNewLine); // Add in dictionary
                // newline = new GameObject("Line " + i);
                newLine.transform.parent = gameObject.transform; // Add how child

                xPosCreateLine = xPosCreateLine + 5.76f;
            }
            xPosCreateLine = -6.3f;
            yPosCreateLine = -2.24f;
        }
        xPosCreateLine = -6.3f;
    }

    private IEnumerator AddSpeedLine()
    {
        while (true)
        {
            yield return new WaitForSeconds(frequencyAddSpeed);

            foreach (var lineInPool in poolLines)
            {
                lineInPool.Value.SpeedLine += addSpeed;; // добавляем скорость 
            }
        }
    }
}
    

