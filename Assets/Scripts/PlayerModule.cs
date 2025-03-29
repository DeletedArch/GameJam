using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerModule : MonoBehaviour
{
    public float DamageRate = 1.0f;
    public int maxHealth = 100 ;
    public int currentHealth ;
    public HealthBar healthBar;
    public GameObject[] Weapons;
    private bool DamageCooldown = false;
    public int DamageCooldownTime = 1;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            gameManager.GameOver();
            CallAfterDelay.Create(3f, () => gameManager.RestartGame());
        }
    }

    private IEnumerator EnemyDamage()
    {
        WaitForSeconds wait = new WaitForSeconds(DamageRate);
        while (true)
        {
            yield return wait;
            DamageCooldown = true;
            TakeDamage(10);
            CallAfterDelay.Create(DamageCooldownTime, () => DamageCooldown = false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy" && DamageCooldown == false)
        {
            StartCoroutine(EnemyDamage());
            
        } else if (collision.gameObject.tag == "Coin")
        {   GameManager.instance.AddCoin();
            Destroy(collision.gameObject);
            Debug.Log("Coin collected!");
        } else if (collision.gameObject.tag == "BigCoin") {
            Destroy(collision.gameObject);
            if (currentHealth >= maxHealth) {
                currentHealth = maxHealth;
            } else if (currentHealth < maxHealth) {
                currentHealth += 5;
                healthBar.SetHealth(currentHealth);
            }
            Debug.Log("Big Coin collected!");
            GameManager.instance.AddCoin();
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines();
    }
}








