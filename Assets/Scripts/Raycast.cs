using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private bool isRayHit;
    [SerializeField] private float safeDistance = 8f;

    // Start is called before the first frame update
    void Start()
    {
        isRayHit = false;
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
                isRayHit = true;
            }
        }
        else
        {
            isRayHit = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x + safeDistance, this.transform.position.y, this.transform.position.z));
    }

    public bool IsRayHit()
    {
        return isRayHit;
    }
}
