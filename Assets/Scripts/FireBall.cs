using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using System.Threading.Tasks;

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
            Debug.Log(Input.mousePosition);
            Debug.Log("Fire");
            GameObject Temp = Instantiate(Bullet, SpawnPoint.position, SpawnPoint.rotation);
            if (Temp != null) {
                Temp.GetComponent<Rigidbody2D>().AddForce((-SpawnPoint.position +Camera.main.ScreenToWorldPoint(Input.mousePosition)) * FireForce * Time.deltaTime);
            }
            
            CallAfterDelay.Create(3, () => DestroyGameObject(ref Temp));
        }

    }

    private void DestroyGameObject(ref GameObject obj)
    {
        Debug.Log("Destroying GameObject");
        Destroy(obj);
    }
}
