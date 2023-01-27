using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private int timeTillSpawn;
    public GameObject[] objectPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 5;
        timeTillSpawn = 6;
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

        Transform child = transform.GetChild(0);
        var firstWaypoint = child.GetComponent<Waypoint>();

        GameObject obj = Instantiate(objectPrefab[randomIndex], firstWaypoint.transform);
        obj.GetComponent<CarAI>().currentWaypoint = firstWaypoint;
        timer = 0;

        return obj;
    }
}
