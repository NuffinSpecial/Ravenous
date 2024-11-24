using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// This is the health class which manipulates public class UI : MonoBehaviour
public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100; 

    void Start()
    {
    
    }
    void Update() 
    { 
// This changes the input and dmg amount
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
    
// This changes the input and heal amount
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
        if (healthAmount == 0)
        {
            print("You Died!");
        }
    }
// This is the dmg function
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount /100f;
    }
// This is the heal function
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0,100);
        healthBar.fillAmount = healthAmount /100f;
    }
}