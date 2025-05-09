using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] PlayerController plr;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform foot;

    public bool attacking => attackTimer > 0;
    float attackTimer = 0;
    float cooldownTimer = 0;

    [SerializeField] float attackLength = 1;
    [SerializeField] float cooldownLength = 1.5f;

    [SerializeField] LayerMask enemyMask;

    [SerializeField] Renderer playerRenderer;
    


    void Update()
    {
        // Manage attack timer behavior
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer < 0)
            {
                EndAttack();
            }
        }

        // Manage cooldown timer behavior
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Manage cooldown timer behavior


        // Start an attack if permitted
        if (Input.GetKeyDown(KeyCode.E) && cooldownTimer <= 0 && !attacking)
        {
            StartAttack();
        }

     
    }

    

    void StartAttack()
    {
        attackTimer = attackLength;
        
    }

    void EndAttack()
    {
        cooldownTimer = cooldownLength;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damagable))
        {
            if (attacking)
            {
                damagable.OnAttack(plr);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damagable))
        {
            if (attacking)
            {
                damagable.OnAttack(plr);
            }
        }
    }
}