using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using System.Threading.Tasks;

public class Shuriken : MonoBehaviour
{
    public GameObject Bullet;
    public Transform SpawnPoint;
    public float FireForce = 100f;
    public Transform Target;
    public float DamageCooldownTime = 1f;
    public bool DamageCooldown = false;
    Vector3 ve = new Vector3(0f, -0.6f,0f);
    float Distance2;


    public void FixedUpdate()
    {
        Distance2 = Vector2.Distance(transform.position, Target.transform.position);
        if (DamageCooldown == false && Distance2 >= 5f)
        {
            DamageCooldown = true;
            Debug.Log("Fire");
            SoundManager.PlaySound(SoundType.fire);
            GameObject Temp = Instantiate(Bullet, SpawnPoint.position + ve , SpawnPoint.rotation);
            
            if (Temp != null) {
                
                Vector2 firePos = -SpawnPoint.position + Target.position;
                Temp.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(firePos.y, firePos.x) * Mathf.Rad2Deg);
                Temp.GetComponent<Rigidbody2D>().AddForce(firePos.normalized * FireForce * Time.deltaTime);
            }
            
            CallAfterDelay.Create(5, () => DestroyGameObject(ref Temp));
            CallAfterDelay.Create(DamageCooldownTime, () => DamageCooldown = false);
        }

    }

    private void DestroyGameObject(ref GameObject obj)
    {
        Debug.Log("Destroying GameObject");
        Destroy(obj);
    }
}
