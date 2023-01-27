using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarAI : StateMachine
{
    public float speed = 10f;
    public float rotSpeed = 100f;
    public float stopDistance = 1f;
    public Waypoint currentWaypoint;

    public BoxCollider avoidZone;
    public CapsuleCollider forwardViewZone;
    public CapsuleCollider rightViewZone;
    public CapsuleCollider leftViewZone;

    protected override BaseState GetInitialState()
    {
        avoidZone = GetComponents<BoxCollider>()[1];
        var viewZones = GetComponents<CapsuleCollider>();
        forwardViewZone = viewZones[0];
        rightViewZone = viewZones[1];
        leftViewZone = viewZones[2];

        return new GoToDestination(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        GetCurrentState().OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        GetCurrentState().OnTriggerExit(other);
    }

    private CarAiState GetCurrentState()
    {
        return (CarAiState)currentState;
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
