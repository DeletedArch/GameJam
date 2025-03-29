using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModule : MonoBehaviour
{
    public float AttackCoolDawn = 1.0f;
    public float Health = 100;
    public SpriteRendererScript spriteRenderer;
    public GameObject Coin;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRendererScript>();
    }
    private IEnumerator EnemyAttackAnimation()
    {
        WaitForSeconds wait = new WaitForSeconds(AttackCoolDawn);
        while (true)
        {
            yield return wait;
            
            spriteRenderer.isAttacking = true;
            // spriteRenderer.isRunning = false;
            CallAfterDelay.Create(0.5f, () => spriteRenderer.isAttacking = false);
            // CallAfterDelay.Create(1f, () => spriteRenderer.isRunning = true);

        }
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hit");
        if (other.gameObject.tag == "Damage")
        {
            Health -= other.gameObject.GetComponent<DamageScript>().Damage;
            if (Health <= 0)
            {
                Instantiate(Coin, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else if(other.gameObject.tag == "Player")
        {
            Debug.Log("Hit a player");
            StartCoroutine(EnemyAttackAnimation());

        }



    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        StopAllCoroutines();
        
    }

}
