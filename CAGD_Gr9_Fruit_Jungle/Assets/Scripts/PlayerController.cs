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
    public bool isFacingLeft;

    private Rigidbody rb;

    [Header("Health Variables")]
    public int maxHealthPoints = 100;
    public int healthPoints;

    [Header("Combat Variables")]
    public int attackStrength = 10;


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

        }
    }

    private void Move()
    {
        //to move left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingLeft = true;
        }

        //to move right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);
            isFacingLeft = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W)) //ADD CHECK "OnGround" FUNCTION TO CHECK BEFORE JUMPING
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }




}
