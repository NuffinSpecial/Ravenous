using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [FormerlySerializedAs("Fruit")] public Image fruit;
    public float fruitAmount = 100; 

    // Update is called once per frame
    void Update()
    {
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
    }

// This is the dmg function
private void TakeDamage(float damage)
        {
            fruitAmount -= damage;
            fruit.fillAmount = fruitAmount /100f;
        }
// This is the heal function
private void Heal(float healingAmount)
{
    fruitAmount += healingAmount;
    fruitAmount = Mathf.Clamp(fruitAmount, 0, 100);
    fruit.fillAmount = fruitAmount / 100f; 
}
} 
    
