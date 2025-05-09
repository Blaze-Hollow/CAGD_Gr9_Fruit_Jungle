using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] bool canBeAttacked = true;

    [Header("Enemy Health Variables")]
    public int maxEnemyHealthPoints = 100;
   



    void Update()
    {



    }




    public void OnAttack(PlayerController player)
    {
        if (canBeAttacked)
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

        void Die()
        {
            Destroy(gameObject);
        }






    }
}