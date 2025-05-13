/* Author [Diaz,Samuel]
 * Last Updated [04/24/2025]
 * Description [This script is in charge of changing the levels once the player reaches the portal]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public PlayerController PlayerController;


    public int Level;
    // Start is called before the first frame update
    void Start()
    {
      
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {//it changes the scene once the player goes through it
        if (other.GetComponent<PlayerController>())
        {
            
            SceneManager.LoadScene(Level);
        }
    }
}
