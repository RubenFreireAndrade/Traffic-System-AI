using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TrafficLightManager : MonoBehaviour
{
    //public bool isGreenLightOn = false;
    public TrafficLightManager masterReplicate;
    public TrafficLightManager masterReverse;

    private Renderer renderer;
    private Color[] colors;
    private int currentIndex = 0;
    private bool reverse = false;

    [SerializeField] private float timer = 0;
    [SerializeField] private int timeTillChange = 3;
    // Start is called before the first frame update
    void Start()
    {
        colors = new Color[]{Color.red, Color.green};
        renderer = GetComponent<Renderer>();

        ChangeColor(currentIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if(masterReplicate)
        {
            ChangeColor(masterReplicate.GetColorIndex());
            return;
        }
        if(masterReverse)
        {
            ChangeColor((colors.Length - 1) - masterReverse.GetColorIndex());
            return;
        }
        timer += Time.deltaTime;
        if (timer > timeTillChange)
        {
            if (reverse) currentIndex--;
            else currentIndex++;

            ChangeColor(currentIndex);

            if (currentIndex == colors.Length - 1) reverse = true;

            if (currentIndex == 0) reverse = false;

            timer = 0;
        }
    }

    private void ChangeColor(int index)
    {
        renderer.material.color = colors[index];
        //if (index == 0) isGreenLightOn = false;
        //else if (index == 1) isGreenLightOn = true;
    }

    public bool IsGreenLightOn()
    {
        //return isGreenLightOn;
        return true;
    }

    public int GetColorIndex()
    {
        return currentIndex;
    }
}
