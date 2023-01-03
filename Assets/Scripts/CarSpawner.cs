using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] spawnObject;
    public Vector3 spawnPosition;
    public int timeTillNextSpawn = 3;
    
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        Instantiate(Spawn(), transform);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeTillNextSpawn) Instantiate(Spawn(), transform);
    }

    private GameObject Spawn()
    {
        var randomIndex = Random.Range(0, spawnObject.Length);
        timer = 0;
        return spawnObject[randomIndex];
    }
}
