using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopForLights : CarAiState
{
    public StopForLights(CarAI stateMachine) : base("StopForLights", stateMachine)
    {
    }

    public override void Update()
    {
        if (visibleTrafficLight == null || visibleTrafficLight.GetActiveColor() == Color.green)
        {
            ChangeState(new GoToDestination(GetAgent()));
        }
    }
}
