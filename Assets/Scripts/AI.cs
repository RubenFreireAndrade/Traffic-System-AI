using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject Car;
    public float speed = 5.0f;
    public float safeDistance = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.right);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, safeDistance))
        {
            var lastHit = hit.transform.gameObject;
            if(lastHit.CompareTag("Car"))
            {
                Debug.Log("Raycast hit");
                Stop();
            }
        }
        else
        {
            Move();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x + safeDistance, this.transform.position.y, this.transform.position.z));
    }

    private void Stop()
    {
        Car.transform.position += new Vector3(0, 0, 0);
    }

    private void Move()
    {
        Car.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
