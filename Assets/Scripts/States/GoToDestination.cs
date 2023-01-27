using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoToDestination : CarAiState
{
    private Vector3 destination;

    public GoToDestination(CarAI stateMachine) : base("GoToDestination", stateMachine)
    {
    }

    public override void OnEnter()
    {
        this.destination = GetAgent().currentWaypoint.GetPosition();
    }

    public override void Update()
    {
        base.Update();

        if (visibleTrafficLight)
        {
            var distToTrafficLight = Utils.CalculateDist(GetAgent().transform.position, visibleTrafficLight.transform.position);
            if (distToTrafficLight <= GetAgent().GetStopDist() && visibleTrafficLight.GetActiveColor() == Color.red)
            {
                ChangeState(new StopForLights(GetAgent()));
                return;
            }
        }

        foreach (var car in carsInFront)
        {
            var distToCarInFront = Utils.CalculateDist(GetAgent().transform.position, car.position);
            if (distToCarInFront <= GetAgent().GetStopDist())
            {
                if (Utils.IsCarInSensor(car, carsToTheLeft)) continue;

                ChangeState(new StopForTraffic(GetAgent()));
                return;
            }
        }

        Move();
    }

    private void Move()
    {
        Vector3 destinationDirection = Utils.CalculateDir(GetAgent().transform.position, destination);
        float destinationDistance = Utils.CalculateDist(GetAgent().transform.position, destination);

        if (destinationDistance >= 1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
            GetAgent().transform.rotation = Quaternion.RotateTowards(GetAgent().transform.rotation, targetRotation, GetAgent().rotSpeed * 10 * Time.deltaTime);
            GetAgent().transform.Translate(GetAgent().speed * Time.deltaTime * Vector3.forward);
        }
        else
        {
            bool shouldBranch = false;
            if (GetAgent().currentWaypoint.branches != null && GetAgent().currentWaypoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= GetAgent().currentWaypoint.branchRatio ? true : false;
            }

            if (shouldBranch)
            {
                GetAgent().currentWaypoint = GetAgent().currentWaypoint.branches[Random.Range(0, GetAgent().currentWaypoint.branches.Count - 1)];
            }

            if (GetAgent().currentWaypoint.nextWaypoint == null)
            {
                GetAgent().SelfDestruct();
                return;
            }
            GetAgent().currentWaypoint = GetAgent().currentWaypoint.nextWaypoint;
            this.destination = GetAgent().currentWaypoint.GetPosition();
        }
    }
}
