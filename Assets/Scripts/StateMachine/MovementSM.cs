using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector] public Idle idleState;
    [HideInInspector] public Moving moveState;

    private void Awake()
    {
        idleState = new Idle(this);
        moveState = new Moving(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
