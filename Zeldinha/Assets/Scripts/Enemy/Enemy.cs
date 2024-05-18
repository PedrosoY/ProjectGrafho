using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    static float speed = 3;
    float timeAcelerate = 5f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.up = -transform.position;
        timeAcelerate += Time.deltaTime;
        if (timeAcelerate >= 3f)
        {
            timeAcelerate = 0;
            speed += 0.2f;
        }
    }

    public static void ResetSpeed()
    {
        speed = 3;
    }
}
