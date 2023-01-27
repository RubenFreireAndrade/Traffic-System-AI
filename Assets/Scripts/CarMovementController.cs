using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarMovementController : MonoBehaviour
{
    public bool canMove;
    public bool isOnTrigger;
    public float speed = 10f;
    public float rotSpeed = 100f;
    public float stopDistance = 1f;
    public bool isReachedDestination;

    private Vector3 destination;
    private Raycast raycast;
    private TrafficLightManager trafficLight;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        isOnTrigger = false;
        raycast = GetComponent<Raycast>();
        trafficLight = GameObject.FindGameObjectWithTag("TrafficLightManager").GetComponent<TrafficLightManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != destination)
        {
            if(!canMove)
            {
                //var newPosition = transform.position;
            }
            else
            {
                Move();
            }
            //
            if (isOnTrigger)
            {
                if (!trafficLight)
                {
                    canMove = false;
                }
                else
                {
                    canMove = true;
                }
            }
            else
            {
                canMove = true;
            }
            //
            if (raycast.IsRayHit())
            {
                canMove = false;
            }
            //else
            //{
            //    canMove = true;
            //}
        }
    }

  

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        isReachedDestination = true;
    }

    private void Move()
    {
        Vector3 destinationDirection = destination - transform.position;
        destinationDirection.y = 0;

        float destinationDistance = destinationDirection.magnitude;

        if (destinationDistance >= stopDistance)
        {
            isReachedDestination = false;
            Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * 10 * Time.deltaTime);
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
        }
        else
        {
            isReachedDestination = true;
        }
    }
}
