using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAiState : BaseState
{
    public CarAiState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
    }

    public virtual void OnTriggerEnter(Collider other)
    {

    }

    public virtual void OnTriggerExit(Collider other)
    {

    }

    protected CarAI GetAgent()
    {
        return (CarAI)this.stateMachine;
    }
}
