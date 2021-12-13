using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMenu : MonoBehaviour
{
    [Tooltip("Attempt counter text")]
    [SerializeField] private Text attemptCounterText;

    [Tooltip("Duration of the last attempt text")]
    [SerializeField] private Text durationText;

    private int attemptCounter = 0;

    private float timerCurrentAttempt = 0;

    private Coroutine durationAttemptRoutine;
   
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject gameOverMenu;

    private void Awake()
    {
        startMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }

    // Start is called before the first frame update
    public void StartGame()
    {
        DisabledAllMenu();
        AddAttemptCounter();
        durationAttemptRoutine = StartCoroutine(CountingDurationLastAttempt());
        timerCurrentAttempt = 0;
    }

    // Update is called once per frame
    public void StopGame()
    {
        ActivateGameOverMenu();

        StopCoroutine(durationAttemptRoutine);
       

        durationText.text = "Duration of the last attempt :  " + timerCurrentAttempt.ToString() + " s";
        attemptCounterText.text = "Attempt counter :  " + attemptCounter.ToString();
    }
    public void ActivateStartMenu()
    {
        startMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }
    public void ActivateGameOverMenu()
    {
        startMenu.SetActive(false);
        gameOverMenu.SetActive(true);
    }
    public void DisabledAllMenu()
    {
        startMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    IEnumerator CountingDurationLastAttempt()
    {
        while (true)
        {
            //timerCurrentAttempt += Time.deltaTime;
            timerCurrentAttempt ++;
            //Debug.Log("timer")

            yield return new WaitForSeconds(1);
        }
    }

    public void AddAttemptCounter()
    {
        attemptCounter++;
    }
}
