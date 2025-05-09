using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] bool canBeAttacked = true;

    [Header("Enemy Health Variables")]
    public int maxEnemyHealthPoints = 100;
    public int enemyHealthPoints;



    void Update()
    {



    }




    public void OnAttack(PlayerController player)
    {
        if (canBeAttacked)
        {
            
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }






}