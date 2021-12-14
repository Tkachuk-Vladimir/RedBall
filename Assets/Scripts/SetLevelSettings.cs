using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevelSettings : MonoBehaviour
{
    //[Tooltip("Array Game Event Listener")]
   [SerializeField] private List<DifficultyLevelData> difficultyLevel;
   [SerializeField] private PoolObstacle poolObstacle;
   [SerializeField] private BallManager ballManager;

   [SerializeField] private GameObject startButton;
   [SerializeField] private GameObject startButtonf;

   private void Start()
   {
        startButton.SetActive(false);
        startButtonf.SetActive(true);
   }
   public void ReStart()
   {
        startButton.SetActive(false);
        startButtonf.SetActive(true);
   }
   public void EasySetting()
   {
        poolObstacle.SetLevelSettings(difficultyLevel[0]);
        ballManager.SetLevelSettings(difficultyLevel[0]);

        startButton.SetActive(true);
        startButtonf.SetActive(false);
   }
   public void MediumSetting()
   {
        poolObstacle.SetLevelSettings(difficultyLevel[1]);
        ballManager.SetLevelSettings(difficultyLevel[1]);

        startButton.SetActive(true);
        startButtonf.SetActive(false);
    }
   public void HardSetting()
   {
        poolObstacle.SetLevelSettings(difficultyLevel[2]);
        ballManager.SetLevelSettings(difficultyLevel[2]);

        startButton.SetActive(true);
        startButtonf.SetActive(false);
    }

}
