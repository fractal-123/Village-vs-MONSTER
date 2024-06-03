using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int maxHealth = 4;
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 50;
    
    public HealthBar healthBar;

    private bool isDestoryed = false;
    public void Start()
    {
        hitPoints = maxHealth;
        healthBar.SetHealth(hitPoints, maxHealth);    
        
    }

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;
        healthBar.SetHealth(hitPoints, maxHealth);


        if (hitPoints <=  0 && !isDestoryed) 
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            Manager.main.IncreaseCurrency(currencyWorth);
            isDestoryed = true;
            transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }
}
