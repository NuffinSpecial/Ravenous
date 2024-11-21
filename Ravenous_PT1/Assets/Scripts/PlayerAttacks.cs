using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackDamage = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Attack key
        {
            PerformAttack();
        }
    }

    private void PerformAttack()
    {
        Debug.Log("Player attacking!");

        // Process all enemies within attack range
        foreach (var enemy in EnemyManager.GetEnemiesInRange(transform.position, attackRange))
        {
            enemy.TakeDamage(attackDamage);
        }

        // After the attack, remove any enemies that have died
        EnemyManager.RemoveMarkedEnemies();
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the attack range in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}