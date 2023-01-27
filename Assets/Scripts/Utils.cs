using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static Vector3 CalculateDir(Vector3 from, Vector3 to)
    {
        Vector3 dirToDest = to - from;
        dirToDest.y = 0;
        return dirToDest;
    }

    public static float CalculateDist(Vector3 from, Vector3 to)
    {
        Vector3 dirToDest = CalculateDir(from, to);
        return dirToDest.magnitude;
    }

    public static bool IsCarInSensor(Transform car, List<Transform> carsInSensor)
    {
        return carsInSensor.Find(c => c.position == car.position) != null;
    }
}
