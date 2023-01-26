using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseState
{
    public string name;
    protected StateMachine stateMachine;
    protected MovementSM _stateM;

    public BaseState(string name, StateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }
    public virtual void OnEnter() { }
    public virtual void Update() { }
    public virtual void OnExit() { }
}
