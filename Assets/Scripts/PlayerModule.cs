using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerModule : MonoBehaviour
{
    public int maxHealth = 100 ;
    public int currentHealth ;
    public HealthBar healthBar;
    public GameObject[] Weapons;
    private bool DamageCooldown = false;
    public int DamageCooldownTime = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy" && DamageCooldown == false)
        {
            DamageCooldown = true;
            TakeDamage(10);
            CallAfterDelay.Create(DamageCooldownTime, () => DamageCooldown = false);
        }
    }
}
