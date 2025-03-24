using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Target;
    public float EnemySpeed = 5.0f;
    public float Distance = 5;
    float Distance2 = 0;
    void Update()
    {
        Distance2 = Vector2.Distance(transform.position, Target.transform.position);
        if(Distance <= Distance2) 
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, EnemySpeed * Time.deltaTime);
    }
}
