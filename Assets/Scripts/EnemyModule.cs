using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModule : MonoBehaviour
{
    // Start is called before the first frame update

    public float Health = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hit");
        if(other.gameObject.tag == "Damage") {
            Health -= other.gameObject.GetComponent<DamageScript>().Damage;
            if(Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
