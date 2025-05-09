using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Andrade, Maya
 * Created: 05/08/2025
 * Last Updated: 05/08/2025
 * Description: This triggers the Durian movement behavior (script is on the extra mesh under the durian, the trigger space)
 */
public class DurianSensor : MonoBehaviour
{
    public DurianEnemy durian;
    private bool canDetect = true;

    // Update is called once per frame
    void Update()
    {
        if (!durian.movingDown && !durian.movingUp)
        {
            canDetect = true;
        }
        else
        {
            canDetect = false;
        }
    }

    //Detects if the player is underneath the Durian, if so it triggers the moving down function on DurianEnemy script
    private void OnTriggerEnter(Collider other)
    {
        if (canDetect == true && other.tag == "Player")
        {
            durian.PlayerDetected();
        }
    }
}
