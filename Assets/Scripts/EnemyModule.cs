using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModule : MonoBehaviour
{
    // Start is called before the first frame update

    public float Health = 100;
    public SpriteRendererScript spriteRenderer;
    public GameObject Coin;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRendererScript>();
    }
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
                Instantiate(Coin, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        } else if (other.gameObject.tag == "Player")
            {
                Debug.Log("Hit a player");
                spriteRenderer.isAttacking = true;
                // spriteRenderer.isRunning = false;
                CallAfterDelay.Create(0.5f, () => spriteRenderer.isAttacking = false);
                // CallAfterDelay.Create(1f, () => spriteRenderer.isRunning = true);
        }
    }
}
