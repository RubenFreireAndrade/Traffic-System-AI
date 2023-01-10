using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightManager : MonoBehaviour
{
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Maybe do time based traffic light system?
    }

    private void ChangeGreen()
    {
        renderer.material.color = Color.green;
    }

    private void ChangeRed()
    {
        renderer.material.color = Color.red;
    }
}
