using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopForTraffic : CarAiState
{
    public StopForTraffic(CarAI stateMachine) : base("StopForTraffic", stateMachine)
    {
    }

    public override void OnEnter()
    {

    }

    public override void Update()
    {
        base.Update();

        foreach (var car in carsInFront)
        {
            var distToCarInFront = Utils.CalculateDist(GetAgent().transform.position, car.position);
            if (distToCarInFront <= GetAgent().GetStopDist())
            {
                return;
            }
        }
        ChangeState(new GoToDestination(GetAgent()));
    }
}
