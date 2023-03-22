using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonLight : MonoBehaviour
{
    Light nl;
    int minRange = 10;
    int maxRange = 20;
    float lastLightTime;
    public float lightTime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLightTime();
        nl = gameObject.GetComponent<Light>();
        nl.range = minRange;
    }

    void UpdateLightTime()
    {
        lastLightTime= Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > lastLightTime + lightTime) 
        {
            if(nl.range == minRange)
            {
                nl.range = maxRange;
            }
            else
            {
                nl.range = minRange;
            }
            UpdateLightTime();
        }
    }
}
