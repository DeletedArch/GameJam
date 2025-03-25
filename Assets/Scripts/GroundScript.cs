using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{

    public GameObject player;
    public Vector3 Offset;
    public float Damping;
    Vector3 val = Vector3.zero;
    public MeshRenderer meshRenderer;
    public Rigidbody2D playerRb;
    public float GroundSpeedOffset = 0.2f;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        playerRb = player.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position,player.transform.position + Offset, ref val, Damping);
    }

    void Update() {
        meshRenderer.material.mainTextureOffset += new Vector2(playerRb.velocity.x *Time.deltaTime * GroundSpeedOffset, playerRb.velocity.y*Time.deltaTime *GroundSpeedOffset);
    }
}
