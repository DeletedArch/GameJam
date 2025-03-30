using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float maxHealth = 100 ;
    public float currentHealth;
    public float AttackCoolDawn = 1.0f;
    public SpriteRendererScript spriteRenderer;
    public GameObject Coin;
    public HealthBar healthBar;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRendererScript>();
    }

    void Start()
    {
        currentHealth = (int)maxHealth;
        healthBar.SetMaxHealth((int)maxHealth);
    }
    private IEnumerator EnemyAttackAnimation()
    {
        WaitForSeconds wait = new WaitForSeconds(AttackCoolDawn);
        while (true)
        {
            yield return wait;
            spriteRenderer.isAttacking = true;
            SoundManager.PlaySound(SoundType.Sowrd);
            // spriteRenderer.isRunning = false;
            CallAfterDelay.Create(0.5f, () => spriteRenderer.isAttacking = false);
            // CallAfterDelay.Create(1f, () => spriteRenderer.isRunning = true);

        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hit");
        if (other.gameObject.tag == "Damage")
        {
            maxHealth -= other.gameObject.GetComponent<DamageScript>().Damage;
            healthBar.SetHealth((int)maxHealth);
            if (maxHealth <= 0)
            {
                Instantiate(Coin, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else if(other.gameObject.tag == "Player")
        {
            SoundManager.PlaySound(SoundType.Sowrd);
            spriteRenderer.isAttacking = true;
            // spriteRenderer.isRunning = false;
            CallAfterDelay.Create(0.5f, () => spriteRenderer.isAttacking = false);
            // CallAfterDelay.Create(1f, () => spriteRenderer.isRunning = true);
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

