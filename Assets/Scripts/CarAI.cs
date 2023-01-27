using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarAI : StateMachine
{
    public float speed = 10f;
    public float rotSpeed = 100f;
    public Waypoint currentWaypoint;

    private float stopDistance = 10f;

    protected override BaseState GetInitialState()
    {
        return new GoToDestination(this);
    }

    public void OnSensorEnter(string sensorName, Collider other)
    {
        GetCurrentState().OnSensorEnter(sensorName, other);
    }

    public void OnSensorExit(string sensorName, Collider other)
    {
        GetCurrentState().OnSensorExit(sensorName, other);
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

    public float GetStopDist()
    {
        return stopDistance;
    }

    public CarAiState GetCurrentState()
    {
        return (CarAiState)currentState;
    }
}
