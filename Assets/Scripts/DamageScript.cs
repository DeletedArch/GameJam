using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public Rigidbody2D FireBall;
    public float Damage = 10f;
    public SpriteRendererScript SpriteRendererScript;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            SpriteRendererScript.isIdling = true;
            SpriteRendererScript.isAttacking = false;
            FireBall.velocity = Vector3.zero;
            Invoke("OnDestroy",0.6f);
        }
    }
    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
