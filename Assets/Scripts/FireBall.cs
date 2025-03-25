using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject Bullet;
    public Transform SpawnPoint;
    public void Update()
    {
        bool Shoot = Input.GetButtonDown("Fire1");
        if (Shoot)
        {
            Instantiate(Bullet, SpawnPoint.position, SpawnPoint.rotation);
        }

    }
}
