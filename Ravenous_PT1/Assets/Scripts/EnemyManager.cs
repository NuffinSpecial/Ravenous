using System.Collections.Generic;
using UnityEngine;

public static class EnemyManager
{
    private static readonly List<Enemy> ActiveEnemies = new();
    private static readonly List<Enemy> EnemiesToRemove = new(); // List to track enemies to remove

    public static void RegisterEnemy(Enemy enemy)
    {
        if (!ActiveEnemies.Contains(enemy))
            ActiveEnemies.Add(enemy);
    }

    public static void UnregisterEnemy(Enemy enemy)
    {
        ActiveEnemies.Remove(enemy);
    }

    // Perform a safe operation to get all enemies in range
    public static IEnumerable<Enemy> GetEnemiesInRange(Vector2 position, float range)
    {
        foreach (var enemy in ActiveEnemies)
        {
            if (Vector2.Distance(position, enemy.transform.position) <= range)
            {
                yield return enemy;
            }
        }
    }

    // Call this method after performing an attack or other actions to remove enemies
    public static void RemoveMarkedEnemies()
    {
        foreach (var enemy in EnemiesToRemove)
        {
            ActiveEnemies.Remove(enemy);
            enemy.gameObject.SetActive(false); // Disable or destroy the enemy
        }
        EnemiesToRemove.Clear(); // Clear the removal list after processing
    }

    // Call this method to mark an enemy for removal
    public static void MarkEnemyForRemoval(Enemy enemy)
    {
        if (!EnemiesToRemove.Contains(enemy))
            EnemiesToRemove.Add(enemy);
    }
}