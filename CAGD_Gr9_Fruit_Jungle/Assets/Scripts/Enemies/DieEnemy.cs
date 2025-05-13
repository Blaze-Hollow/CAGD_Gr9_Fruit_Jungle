using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Samu, Omar
 * Created: 05/09/2025
 * Last Updated: 05/11/2025
 * Description: Allows enemy to be damaged and drop something on death
 */

public class DieEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] bool canBeAttacked = true;
    [SerializeField] private float damageCooldown = 1.5f;


    [Header("Enemy Health Variables")]
    public int maxEnemyHealthPoints = 100;
    public GameObject drop;
    public bool dropped;

    private float lastHitTime = 0;

    public void Start()
    {
        dropped = false;
    }
    public void OnAttack(PlayerController player)
    {

        if (canBeAttacked && Time.time > lastHitTime + damageCooldown)
        {
            lastHitTime = Time.time; // Update the last hit time

            if (maxEnemyHealthPoints > 0)
            {
                maxEnemyHealthPoints -= 50;
            }
            else if (maxEnemyHealthPoints <= 0)
            {
                Die();
            }
        }


        void Die()
        {
            if (dropped == false)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
                dropped = true;
            }
            Destroy(gameObject);
        }






    }
}


/*if (canBeAttacked)
{

    if (maxEnemyHealthPoints > 0)
    {
        maxEnemyHealthPoints -= 50;
    }
    else if (maxEnemyHealthPoints <= 0)
    {
        Die();
    }

}
*/