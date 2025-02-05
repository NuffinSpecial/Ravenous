using UnityEngine;
using UnityEngine.UI;
// This is the health class which manipulates public class UI : MonoBehaviour
public class HealthManager : MonoBehaviour
{
    public Image health;
    public float healthAmount = 100;



    private void Update() 
    { 
// This changes the input and dmg amount
        if (Input.GetKeyDown(KeyCode.M))
        {
            TakeDamage(10);
        }
    
// This changes the input and heal amount
        if (Input.GetKeyDown(KeyCode.N))
        {
            Heal(10);
        }
        
    }
// This is the dmg function
private void TakeDamage(float damage)
    {
        healthAmount -= damage;
        health.fillAmount = healthAmount /100f;
    }
// This is the heal function
private void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0,100);
        health.fillAmount = healthAmount /100f;
    }
}