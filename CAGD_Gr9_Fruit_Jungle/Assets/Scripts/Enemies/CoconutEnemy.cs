/* Author [Diaz,Samuel]
 * Last Updated [04/29/2025]
 * Description [This script is in charge of the behaviour of the Coconut Enemy]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutEnemy : MonoBehaviour
{
    public int Health = 10;
    public bool dropped;
    public float moveSpeed = 10f;
    Rigidbody rb;
   public Transform target;
    Vector3 moveDirection;
    public GameObject CoconutDrop;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()


    {
        
        target = GameObject.Find("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - moveDirection).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
           // rb.rotation = angle;
            moveDirection = direction;

        }

        if (Health <= 0)
        {

            if (dropped == false)
            {
                Instantiate(CoconutDrop, transform.position, Quaternion.identity);
                dropped = true;
            }
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z) * moveSpeed;  
        }
    }


    private void OnTriggerEnter(Collider other)
    {
       // if (other.tag("Player"))
        {

        }
    }
}
