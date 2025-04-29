using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Name: Omar Samu and Maya Andrade
 * Date: 04/06/25
 * Last Updated: 04/20/25
 * Description: Allows player movement
 */
public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    public int speed = 10;
    public int jumpForce = 7;

    private Rigidbody rb;

    [Header("Health Variables")]
    public int maxHealthPoints = 100;
    public int healthPoints;

    [Header("Combat Variables")]
    public int attackStrength = 10;
    public int fruitScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        healthPoints = maxHealthPoints;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!ScreenManager.gameIsPaused)
        {
            Move();
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (!ScreenManager.gameIsPaused)
        {

            //TEMPORARY- REMOVE BEFORE SUMBITTING
            if (Input.GetKeyDown(KeyCode.P))
            {
                healthPoints -= 10;
            }


            if (healthPoints <= 0) //checks to see if player has "died" yet or not
            {
                SceneManager.LoadScene(3);
                print("GAME OVER =[");
            }

            Jump();
            Move();


        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Move right
            rb.MovePosition(transform.position += (Vector3.right * speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Move right
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //Move right
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //Move right
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            Debug.Log("Jump Attempted!");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }


    private bool OnGround()
    {
        bool onGround = false;

       
        Rigidbody rb = GetComponent<Rigidbody>();

        // Check if the player's velocity along the Y-axis is approximately zero
        if (Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            onGround = true;
        }

        return onGround;
    }



    public void Bounce()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce * 0.666f, rb.velocity.z);
    }

}



