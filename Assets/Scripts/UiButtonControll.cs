using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButtonControll : MonoBehaviour
{
   [SerializeField] private GameEvent OnCickButton;

   public void ClickOnButton()
   {
        OnCickButton.Raise();
   }
}
