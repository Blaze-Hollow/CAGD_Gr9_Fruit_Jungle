using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Name: Omar Samu 
 * Date: 04/06/25
 * Last Updated: 05/01/25
 * Description: Allows player movement with raycast collision prevention
 */
public class PlayerController : MonoBehaviour
{
    Animation anim;

    [Header("Movement Variables")]
    public int speed = 10;
    public int jumpForce = 7;

    private Rigidbody rb;

    [Header("Health Variables")]
    public static int maxHealthPoints = 100;
    public static int healthPoints;

    [Header("Combat Variables")]
    public int attackStrength = 10;
    public static int fruitScore = 0;
    public float killHeight = -10;

    private static PlayerController instance;

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
            // Call movement from FixedUpdate for consistent physics updates.
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
            // TEMPORARY - REMOVE BEFORE SUBMITTING
            if (Input.GetKeyDown(KeyCode.P))
            {
                healthPoints -= 10;
            }

            if (healthPoints <= 0)
            {
                SceneManager.LoadScene(4);
                Debug.Log("GAME OVER =[");
            }

            Jump();
            //  If you want movement updates every frame, you may call Move() here too.
            if (anim.isPlaying == false)
            {
                anim.Play("Idle");
            }
        }
    }

    private void Move()
    {
        // Right movement
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (CanMove(Vector3.right))
            {
                anim.Play("Jog");
                //rb.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                anim.Play("Idle");
            }
        }

        // Left movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (CanMove(Vector3.left))
            {
                anim.Play("Jog");
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else
            {
                anim.Play("Idle");
            }
        }

        // Backward movement
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (CanMove(Vector3.back))
            {
                anim.Play("Jog");
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
            else
            {
                anim.Play("Idle");
            }
        }

        // Forward movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (CanMove(Vector3.forward))
            {
                anim.Play("Jog");
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
            else
            {
                anim.Play("Idle");
            }
        }
    }

    // Casts a ray in the intended direction to see if a wall is blocking
    private bool CanMove(Vector3 direction) 
    {
        // Calculate the distance for the raycast based on the current movement step
        float movementStep = speed * Time.deltaTime;
        float rayDistance = movementStep + 0.2f; // Adding a small buffer

        RaycastHit hit;
        // Cast the ray from the player's position in the specified direction.
        if (Physics.Raycast(transform.position, direction, out hit, 0.5f))
        {
            // Check if the hit object has your wall script/component.
            if (hit.collider.GetComponent<Wall>() != null)
            {
                return false;
            }
        }
        return true;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            anim.Play("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Checks if the player is on the ground by the y axis :)
    private bool OnGround()
    {
       
        // Check if the player's vertical velocity is nearly zero.
        if (Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            return true;
        }
        return false;
    }

    public void Bounce()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce * 0.666f, rb.velocity.z);
    }
}
