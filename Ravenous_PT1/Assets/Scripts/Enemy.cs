using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth = 50f;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        EnemyManager.RegisterEnemy(this);
    }

    private void OnDisable()
    {
        EnemyManager.UnregisterEnemy(this);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log($"{name} took {damage} damage. Remaining health: {_currentHealth}");

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log($"{name} has been defeated!");
        // Perform any death effects or animations here
        EnemyManager.MarkEnemyForRemoval(this); // Mark this enemy for removal
    }
}