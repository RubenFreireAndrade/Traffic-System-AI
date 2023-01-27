using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected BaseState currentState;

    void Start()
    {
        currentState = GetInitialState();
        if(currentState != null) currentState.OnEnter();
    }

    void Update()
    {
        if(currentState != null) currentState.Update();
    }

    public void ChangeState(BaseState newState)
    {
        currentState.OnExit();
        currentState = newState;
        currentState.OnEnter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "{no current state}";
        GUILayout.Label($"<color='white'><size=40>{content}</size></color>");
    }
}
