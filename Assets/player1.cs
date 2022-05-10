using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
  public HealthBar healthBar;
  	public PlayerMovement controller;
    public float maxHealth = 100f;
 float currentHealth;
float blockDamage = 0.05f;
        // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
      if(controller.block == true){
        healthBar.SetHealth(currentHealth);
        currentHealth -= damage * blockDamage;

      } else if (controller.block == false){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        //insert hurt animation
}
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Debug.Log("Player 2 wins");
        Destroy(gameObject);
    }
}
