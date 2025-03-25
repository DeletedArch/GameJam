using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public Vector3 Offset;
    public float Damping;
    Vector3 val = Vector3.zero;
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position,player.transform.position + Offset, ref val, Damping);
    }
}
