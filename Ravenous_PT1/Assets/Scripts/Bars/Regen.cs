using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class Regen : MonoBehaviour
{
    [FormerlySerializedAs("Veggie")] public Image veggie;
    public float veggieAmount = 100;
    // Start is called before the first frame update

    private void Update()
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
// Dmg function
private void TakeDamage(float damage)
{
    veggieAmount -= damage;
    veggie.fillAmount = veggieAmount /100f;
}
// Heal function
private void Heal(float healingAmount)
    {
        veggieAmount += healingAmount;
        veggieAmount = Mathf.Clamp(veggieAmount, 0, 100);
        veggie.fillAmount = veggieAmount / 100f; 
    }       
}
