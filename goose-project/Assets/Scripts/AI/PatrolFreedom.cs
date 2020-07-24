﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFreedom : MonoBehaviour
{
    public float speed;
    public float startWaitTime;
    public Vector3 minValues, maxValues;
    public Transform moveSpot;

    private float waitTime;

    private void Start()
    {
        moveSpot.position = new Vector3(Random.Range(minValues.x, maxValues.x), Random.Range(minValues.y, maxValues.y), Random.Range(minValues.z, maxValues.z));
        transform.LookAt(moveSpot);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        // Check if the distance between this and the movepoint is less than 0.2f (tollerange range)
        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                moveSpot.position = new Vector3(Random.Range(minValues.x, maxValues.x), Random.Range(minValues.y, maxValues.y), Random.Range(minValues.z, maxValues.z));
                transform.LookAt(moveSpot);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime = -Time.deltaTime;
            }
        }
    }
}
