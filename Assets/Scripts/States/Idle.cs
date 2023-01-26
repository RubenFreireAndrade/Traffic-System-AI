using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{
    public Idle(MovementSM stateMachine) : base("Idle", stateMachine) 
    {
        this._stateM = (MovementSM)stateMachine;
    }
    //public MoveState moveState;

    private TrafficLightManager trafficLight;

    public override void OnEnter()
    {
        base.OnEnter();
        trafficLight = GameObject.FindGameObjectWithTag("TrafficLightManager").GetComponent<TrafficLightManager>();
    }

    public override void Update()
    {
        base.Update();
        if (trafficLight.IsGreenLightOn()) stateMachine.ChangeState(_stateM.moveState);
    }

    //private void Awake()
    //{
    //    trafficLight = GameObject.FindGameObjectWithTag("TrafficLightManager").GetComponent<TrafficLightManager>();
    //    Debug.Log("Entered IdleState");
    //}

    //public override StateMachine RunCurrentState()
    //{
    //    if (trafficLight.IsGreenLightOn()) return moveState;

    //    return this;
    //}
}
