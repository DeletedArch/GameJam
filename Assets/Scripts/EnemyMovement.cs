﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject Target;
    public float EnemySpeed = 5.0f;
    public float Distance = 2;
    float Distance2 = 0;

    void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Distance2 = Vector2.Distance(transform.position, Target.transform.position);
        if(Distance <= Distance2) 
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, EnemySpeed * Time.deltaTime);
        Vector3 scale = transform.localScale;
        if (Target.transform.position.x > transform.position.x)
            scale.x = Mathf.Abs(transform.localScale.x);
        else
            scale.x = Mathf.Abs(transform.localScale.x) * -1;
        transform.localScale = scale;
    }
}
