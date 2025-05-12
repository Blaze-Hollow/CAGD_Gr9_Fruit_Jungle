using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Andrade, Maya
 * Created: 05/06/2025
 * Last Updated: 05/11/2025
 * Description: When an enemy dies, it drops an item with this script, which once collided with by the player, increases their score
 */

public class EnemyDrop : MonoBehaviour
{
    public int fruitPoints = 5;
    public int dropDespawnTime = 5;

    private void Start()
    {
        StartCoroutine(DespawnTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().fruitScore += fruitPoints;
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Despawns the drop after x amount of seconds
    /// </summary>
    IEnumerator DespawnTime()
    {
        yield return new WaitForSeconds(dropDespawnTime);
        Destroy(gameObject);
    }
}
