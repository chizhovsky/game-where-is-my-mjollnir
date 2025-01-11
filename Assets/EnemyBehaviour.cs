using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int _maxHealth = 100;
    public int _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        // Play hurt animation

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy died!");

        // Die animation

        // Diasble the enemy
    }

}
