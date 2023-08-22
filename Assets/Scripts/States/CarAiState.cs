using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAiState : BaseState
{
    public TrafficLightManager visibleTrafficLight;
    public List<Transform> carsTooClose;
    public List<Transform> carsInFront;
    public List<Transform> carsToTheRight;
    public List<Transform> carsToTheLeft;

    public CarAiState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        this.carsTooClose = new List<Transform>();
        this.carsInFront = new List<Transform>();
        this.carsToTheRight = new List<Transform>();
        this.carsToTheLeft = new List<Transform>();
    }

    public override void Update()
    {
        /** In case car reached destination and was Destroyed removing it from carsInFront **/
        carsTooClose.RemoveAll(car => car == null);
        carsInFront.RemoveAll(car => car == null);
        carsToTheRight.RemoveAll(car => car == null);
        carsToTheLeft.RemoveAll(car => car == null);
    }

    public virtual void OnSensorEnter(string sensorName, Collider other)
    {
        if (sensorName == "ForwardViewZone" && other.CompareTag("TrafficLightManager"))
        {
            visibleTrafficLight = other.gameObject.GetComponentInChildren<TrafficLightManager>();
        }
        if (sensorName == "AvoidViewZone" && other.CompareTag("Car"))
        {
            carsTooClose.Add(other.transform);
        }
        if (sensorName == "ForwardViewZone" && other.CompareTag("Car"))
        {
            carsInFront.Add(other.transform);
        }
        if (sensorName == "RightViewZone" && other.CompareTag("Car"))
        {
            carsToTheRight.Add(other.transform);
        }
        if (sensorName == "LeftViewZone" && other.CompareTag("Car"))
        {
            carsToTheLeft.Add(other.transform);
        }
    }

    public virtual void OnSensorExit(string sensorName, Collider other)
    {
        if (sensorName == "ForwardViewZone" && other.gameObject.tag == "TrafficLightManager")
        {
            visibleTrafficLight = null;
        }
        if (sensorName == "AvoidViewZone" && other.gameObject.tag == "Car")
        {
            carsTooClose.RemoveAll(car => car == null || car.position == other.transform.position);
        }
        if (sensorName == "ForwardViewZone" && other.gameObject.tag == "Car")
        {
            carsInFront.RemoveAll(car => car == null || car.position == other.transform.position);
        }
        if (sensorName == "RightViewZone" && other.gameObject.tag == "Car")
        {
            carsInFront.RemoveAll(car => car == null || car.position == other.transform.position);
        }
        if (sensorName == "LeftViewZone" && other.gameObject.tag == "Car")
        {
            carsInFront.RemoveAll(car => car == null || car.position == other.transform.position);
        }
    }

    protected void ChangeState(CarAiState nextState)
    {
        /** Passing data to the next state **/
        nextState.carsInFront = carsInFront;
        nextState.visibleTrafficLight = visibleTrafficLight;

        GetAgent().ChangeState(nextState);
    }

    protected CarAI GetAgent()
    {
        return (CarAI)this.stateMachine;
    }
}
