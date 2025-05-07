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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void elimination()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       // if (other.tag("Player"))
        {

        }
    }
}
