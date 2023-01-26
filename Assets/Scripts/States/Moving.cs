using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : BaseState
{
    public Moving(MovementSM stateMachine) : base("Moving", stateMachine)
    {
        this._stateM = (MovementSM)stateMachine;
    }
    //public MoveState moveState;

    private TrafficLightManager trafficLight;
    private CarMovementController carMovementController;

    public override void OnEnter()
    {
        base.OnEnter();
        carMovementController.GetComponent<CarMovementController>();
        trafficLight = GameObject.FindGameObjectWithTag("TrafficLightManager").GetComponent<TrafficLightManager>();
    }

    public override void Update()
    {
        base.Update();
        if (!trafficLight.IsGreenLightOn()) stateMachine.ChangeState(_stateM.idleState);
    }

    //private void Awake()
    //{
    //    Debug.Log("Entered MoveState");
    //}
    //public override StateMachine RunCurrentState()
    //{
    //    return this;
    //}
}
