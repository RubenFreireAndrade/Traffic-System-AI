using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    //public List<Car> cars;
    public List<GameObject> objectPrefab;
    public int timeTillSpawn;
    //public Vector3 spawnPosition;

    float timer;
    Vector3 spawnOffset = new Vector3(10, 0, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
        timeTillSpawn = 3;
        //StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeTillSpawn) Instantiate(Spawn(), transform.position + spawnOffset, Quaternion.Euler(0, 90, 0));
    }

    public GameObject Spawn()
    {
        var randomIndex = Random.Range(0, objectPrefab.Count);
        timer = 0;
        return objectPrefab[randomIndex];
    }

    //IEnumerator SpawnTimer()
    //{
    //    yield return new WaitForSeconds(2);
    //    var randomIndex = Random.Range(0, objectPrefab.Count);
    //    Instantiate(objectPrefab[randomIndex], transform);
    //    StartCoroutine(SpawnTimer());
    //}
}
