using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: Andrade, Maya
 * Created: 04/29/2025
 * Last Updated: 05/08/2025
 * Description: This will handle the durian enemy movement and attack
 */

public class DurianEnemy : MonoBehaviour
{
    [Header("Movement Variables")]
    public int speedDown = 10;
    public int speedUp = 7;
    public float midPoint_Y = 2; //middle point from top to bottom of model (for dropping down to floor)
    public Vector3 startingPoint;
    public Vector3 movePoint;
    public bool movingDown;
    public bool movingUp;
    public bool atTop;

    [Header("Health Variables")]
    public int health = 10;
    private bool hasExploded = false;
    public GameObject DurianSplatter;

    // Start is called before the first frame update
    void Start()
    {
        startingPoint.y = transform.position.y;
        atTop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            if (!hasExploded)
            {
            Instantiate(DurianSplatter, transform.position, transform.rotation);
            hasExploded = true;
            }

            Destroy(gameObject);
        }

        if (movingDown)
        {
            MoveDown();
        }

        if (movingUp)
        {
            MoveUp();
        }
    }

    /// <summary>
    /// Using a raycast, the Durian finds the ground so that it doesn't 
    /// accidentally clip through it when it tries to smush the player
    /// </summary>
    private Vector3 FindMovingPoint()
    {
        Vector3 pointToMoveTo;

        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * 20, Color.red);

        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            pointToMoveTo = hit.point + new Vector3(0, midPoint_Y, 0);
        }
        else //if no ground is below
        {
            pointToMoveTo = transform.position - new Vector3(0, 20, 0);
        }
        return pointToMoveTo;
    }

    /// <summary>
    /// Moves the Durian down until it reaches the movepoint that was found with a raycast
    /// </summary>
    private void MoveDown()
    {
        atTop = false;

        transform.position += Vector3.down * speedDown * Time.deltaTime;

        if (transform.position.y <= movePoint.y)
        {
            movingDown = false;

            StartCoroutine(DirectionChanger());
        }
    }

    /// <summary>
    /// After the timer, the Durian moves up until it reaches back to where it started
    /// </summary>
    private void MoveUp()
    {
        atTop = false;

        transform.position += Vector3.up * speedUp * Time.deltaTime;

        if (transform.position.y >= startingPoint.y)
        {
            atTop = true;
            movingUp = false;
        }
    }

    /// <summary>
    /// Makes the Durian pause at the bottom before it goes up
    /// </summary>
    IEnumerator DirectionChanger()
    {
        yield return new WaitForSeconds(2);
        movingUp = true;
    }

    public void PlayerDetected()
    {
        movePoint = FindMovingPoint();
        movingDown = true;
    }
}
