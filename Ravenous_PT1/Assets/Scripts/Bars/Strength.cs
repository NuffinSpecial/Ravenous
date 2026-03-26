using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class Strength : MonoBehaviour
{
    [FormerlySerializedAs("Meat")] public Image meat;
    public float meatAmount = 100;
    // Start is called before the first frame update

    // Update is called once per frame
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
// This is the dmg function
    private void TakeDamage(float damage)
    {
        meatAmount -= damage;
        meat.fillAmount = meatAmount /100f;
    }
// This is the heal function
    private void Heal(float healingAmount)
    {
        meatAmount += healingAmount;
        meatAmount = Mathf.Clamp(meatAmount, 0, 100);
        meat.fillAmount = meatAmount / 100f; 
    }    
}



