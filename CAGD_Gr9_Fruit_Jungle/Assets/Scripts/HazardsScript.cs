/* Author [Diaz,Samuel]
 * Last Updated [04/24/2025]
 * Description [This script is in charge of the damage the player recieves based on the object]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsScript : MonoBehaviour
{
    public int DamageDealt;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().healthPoints -=DamageDealt;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Player )
        {
            
        }
    }

}
