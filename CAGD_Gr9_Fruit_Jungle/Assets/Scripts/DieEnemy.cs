using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] bool canBeAttacked = true;
    [SerializeField] private float damageCooldown = 1.5f;

    [Header("Enemy Health Variables")]
    public int maxEnemyHealthPoints = 100;

    private float lastHitTime = 0;



    void Update()
    {



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