using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightTrigger : MonoBehaviour
{
    private bool isOnTrigger = false;
    //Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Debug.Log("Car On Enter Trigger");
            isOnTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Debug.Log("Car On Enter Trigger");
            isOnTrigger = false;
        }
    }

    public bool GetIsOnTrigger()
    {
        return isOnTrigger;
    }
}
