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
    public int DamageCooldownTime = 1;
    public bool DamageCooldown = false;
    Vector3 ve = new Vector3(0f, -0.6f,0f);



    public void Update()
    {
        bool Shoot = Input.GetButtonDown("Fire1");
        if (Shoot && DamageCooldown == false)
        {
            DamageCooldown = true;
            Debug.Log("Fire");
            GameObject Temp = Instantiate(Bullet, SpawnPoint.position + ve , SpawnPoint.rotation);
            if (Temp != null) {
                Vector2 firePos = -SpawnPoint.position +Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Temp.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(firePos.y, firePos.x) * Mathf.Rad2Deg);
                Temp.GetComponent<Rigidbody2D>().AddForce(firePos.normalized * FireForce * Time.deltaTime);
            }
            
            CallAfterDelay.Create(3, () => DestroyGameObject(ref Temp));
            CallAfterDelay.Create(DamageCooldownTime, () => DamageCooldown = false);
        }

    }

    private void DestroyGameObject(ref GameObject obj)
    {
        Debug.Log("Destroying GameObject");
        Destroy(obj);
    }
}
