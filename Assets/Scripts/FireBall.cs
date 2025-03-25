using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject Bullet;
    public Transform SpawnPoint;
    public float FireForce = 100f;
    public Transform Target;
    public void Update()
    {
        bool Shoot = Input.GetButtonDown("Fire1");
        if (Shoot)
        {
            Instantiate(Bullet, SpawnPoint.position, SpawnPoint.rotation);
            Bullet.GetComponent<Rigidbody2D>().AddForce(Target.position * FireForce);
            
        }

    }
}
