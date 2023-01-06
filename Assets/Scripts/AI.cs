using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject Car;
    public float accel = 5.0f;
    public float maxSpeed;
    public float safeDistance = 8.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, safeDistance))
        {
            var lastHit = hit.transform.gameObject;
            if (lastHit.CompareTag("Car"))
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
        rb.velocity = Vector3.zero;
        //rb.AddForce(transform.forward brakingPower)
        //Car.transform.position += new Vector3(0, 0, 0);
    }

    private void Move()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.forward * accel);
        }
        Debug.Log(rb.transform.position);
        //Car.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
