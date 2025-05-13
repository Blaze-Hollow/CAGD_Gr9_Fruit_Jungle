using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Samu, Omar
 * Created: 05/13/2025
 * Last Updated: 05/13/2025
 * Description: Allows player to attack enemies
 */

public class PlayerAttack : MonoBehaviour
{
    Animation anim;

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

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

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
           anim.Play("Swipe");
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable damagable))
        {
            if (attacking)
            {
                damagable.OnAttack(plr);
            }
        }
    }

}