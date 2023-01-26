//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class StateManager : MonoBehaviour
//{
//    public StateMachine currentState;
//    // Update is called once per frame
//    void Update()
//    {
//        RunStateMachine();
//    }

//    private void RunStateMachine()
//    {
//        StateMachine nextState = currentState?.RunCurrentState();

//        if(nextState != null)
//        {
//            ChangeToNextState(nextState);
//        }
//    }

//    private void ChangeToNextState(StateMachine nextState)
//    {
//        currentState = nextState;
//    }
//}
