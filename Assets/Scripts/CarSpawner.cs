using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private int timeTillSpawn;
    public GameObject[] objectPrefab;

    Vector3 spawnOffset = new Vector3(10, 0, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 2;
        timeTillSpawn = 3;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeTillSpawn) Spawn();
    }

    GameObject Spawn()
    {
        var randomIndex = Random.Range(0, objectPrefab.Length);
        GameObject obj = Instantiate(objectPrefab[randomIndex]);
        Transform child = transform.GetChild(0);
        obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
        obj.transform.position = child.position;
        timer = 0;

        return obj;
    }
}
