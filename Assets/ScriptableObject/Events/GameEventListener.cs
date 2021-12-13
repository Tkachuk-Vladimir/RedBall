using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent buttonEvent; 

    [SerializeField] private UnityEvent response; 

    private void OnEnable() 
    {
        buttonEvent.RegisterListener(this);
    }

    private void OnDisable() 
    {
        buttonEvent.UnregisterListener(this);
    }

    public void OnEventRaised() 
    {
        response.Invoke();
    }
}
