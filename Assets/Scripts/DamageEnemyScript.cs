using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemyScript : MonoBehaviour
{
    public Rigidbody2D FireBall;
    public float Damage = 10f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FireBall.velocity = Vector3.zero;
            OnDestroy();
        }
    }
    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
