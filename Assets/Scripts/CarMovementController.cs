using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementController : MonoBehaviour
{
    public float speed = 10f;
    public float rotSpeed = 100f;
    public float stopDistance = 2f;

    private Vector3 destination;
    public bool isReachedDestination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;

            float destinationDistance = destinationDirection.magnitude;

            if(destinationDistance >= stopDistance)
            {
                isReachedDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * 10 * Time.deltaTime);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                isReachedDestination = true;
            }
        }
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        isReachedDestination = true;
    }
}
