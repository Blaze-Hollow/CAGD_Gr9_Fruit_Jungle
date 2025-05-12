using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Name: Omar Samu and Maya Andrade
 * Date: 04/06/25
 * Last Updated: 05/01/25
 * Description: Allows player movement
 */
public class PlayerController : MonoBehaviour
{

    Animation anim; 

    [Header("Movement Variables")]
    public int speed = 10;
    public int jumpForce = 7;

    private Rigidbody rb;

    [Header("Health Variables")]
    public int maxHealthPoints = 100;
    public int healthPoints;

    [Header("Combat Variables")]
    public int attackStrength = 10;
    public static int fruitScore = 0;
    public float killHeight = -10;


    // Start is called before the first frame update
    void Start()
    {
        healthPoints = maxHealthPoints;
        rb = GetComponent<Rigidbody>();

        anim = GetComponent<Animation>();
        anim.Play("Idle");
    }

    private void FixedUpdate()
    {
        if (!PauseMenu.gameIsPaused)
        {
            Move();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < killHeight)
        {
            SceneManager.LoadScene(4);
        }

        if (!PauseMenu.gameIsPaused)
        {

            //TEMPORARY- REMOVE BEFORE SUMBITTING
            if (Input.GetKeyDown(KeyCode.P))
            {
                healthPoints -= 10;
            }


            if (healthPoints <= 0) //checks to see if player has "died" yet or not
            {
                SceneManager.LoadScene(4);
                print("GAME OVER =[");
            }

            Jump();
            Move(); 

            if (anim.isPlaying == false)
            {
                anim.Play("Idle");
            }

           

        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.Play("Jog");
            //Move right
            rb.MovePosition(transform.position += (Vector3.right * speed * Time.deltaTime));
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.Play("Idle");

        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.Play("Jog");
            //Move right
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.Play("Idle");

        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.Play("Jog");
            //Move right
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.Play("Idle");

        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.Play("Jog");
            //Move right
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.Play("Idle");

        }

        
    }

    private void Jump()
    {
        if (Input.GetKeyUp(KeyCode.Space) && OnGround())
        {
            anim.Play("Jump");
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



