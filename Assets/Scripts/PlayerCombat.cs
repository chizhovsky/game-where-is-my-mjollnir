using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator _animator;
    public Transform _attackPoint;
    public LayerMask _enemyLayers;

    public float _attackRange = 0.7f;
    public int _attackDamage = 40;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        
    }

    void Attack()
    {
        //Play an attack animation
        _animator.SetTrigger("Attack");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);

        //Damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyBehaviour>().TakeDamage(_attackDamage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        //Draw the attacking sphere
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
        
    }
}
