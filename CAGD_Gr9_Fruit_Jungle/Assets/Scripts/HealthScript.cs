/* Author [Diaz,Samuel]
 * Last Updated [04/24/2025]
 * Description [This script is in charge of giving the player health back once they enter in contact with the health pack]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int giveHealth = 30;
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
        if(other.GetComponent<PlayerController>())
        {
            int newHealth = giveHealth + PlayerController.healthPoints;
            PlayerController.healthPoints = Mathf.Clamp(newHealth, 0, 
                PlayerController.maxHealthPoints);

            Destroy(gameObject);
        }
    }
}
