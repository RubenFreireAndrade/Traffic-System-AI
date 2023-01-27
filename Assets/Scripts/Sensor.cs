using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public string sensorName;

    private CarAI agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<CarAI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        agent.OnSensorEnter(sensorName, other);
    }

    private void OnTriggerExit(Collider other)
    {
        agent.OnSensorExit(sensorName, other);
    }
}
