using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Andrade, Maya
 * Created: 05/08/2025
 * Last Updated: 05/08/2025
 * Description: This detects if the player was crushed, insta-killing them
 */
public class DurianCrusher : MonoBehaviour
{
    public DurianEnemy durian;
    public bool canCrush = false;

    // Start is called before the first frame update
    void Start()
    {
        canCrush = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (durian.atTop)
        {
            canCrush = false;
        }
        else
        {
            canCrush = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (canCrush && other.tag == "Player")
        {
            other.GetComponent<PlayerController>().healthPoints = 0;
        }
    }
}
