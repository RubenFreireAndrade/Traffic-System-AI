using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] spawnObject;
    public Vector3 spawnPosition;
    public int timeTillNextSpawn = 5;
    
    float timer;
    //int x = 0;
    //int maxX = 10;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        Instantiate(Spawn(), this.transform);
        //spawnPosition = transform.position;
        //spawnPosition.x = x;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Spawn();
    }

    private GameObject Spawn()
    {
        if(timer >= timeTillNextSpawn)
        {
            var randomIndex = Random.Range(0, spawnObject.Length);
            timer = 0;
            return spawnObject[randomIndex];
            //x = Random.Range(0, maxX);
            //spawnPosition.x = x;
            //Instantiate(spawnObject, spawnPosition, Quaternion.identity);
            //timer = 0;
        }
        return null;
    }
}
