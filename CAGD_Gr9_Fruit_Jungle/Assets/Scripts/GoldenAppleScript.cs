/* Author [Diaz,Samuel]
 * Last Updated [04/29/2025]
 * Description [This script is in charge finishing the game once the player aachieves the apple]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoldenAppleScript : MonoBehaviour
{
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
            SceneManager.LoadScene(5);
        }
        //aaaaa
    }
}
