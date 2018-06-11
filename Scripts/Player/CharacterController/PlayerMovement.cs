using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed, speedLimit, fallMulitplier, jumpVelocity, horizontal;
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool centerGrounded, leftGrounded, rightGrounded, justJumped;
    public AnimationHandler runAni;
    public SpriteRenderer characterBody;
    public Collider2D groundCheck, weapon;
    public GameObject playerPos;
    public AudioSource footSteps, jump;
    public PlayerDetails pDets;


    void Start () {
        speedLimit = 20f;
        centerGrounded = false; 
        rightGrounded = false; 
        leftGrounded = false;
        justJumped = false;
        jumpVelocity = 12;
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<BoxCollider2D>();
        fallMulitplier = 6f;
        speed = 2f;
        footSteps.Play();
    }

    private void FixedUpdate()
    {
        CheckRayCast();

        if (pDets.playerAlive)
        {
            //moving side to side
            if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
            {
                if (centerGrounded)
                {
                    footSteps.UnPause();
                }

                if (Input.GetAxisRaw("Horizontal") > 0.1f)
                {
                    characterBody.flipX = false;
                    if (weapon.transform.position != new Vector3(1, 0, 0))
                    {
                        weapon.transform.position = playerPos.transform.position + new Vector3(1, 0, 0);
                    }

                    if (rb.velocity.magnitude < speedLimit)
                    {
                        if (!centerGrounded)
                        {
                            runAni.Running();
                            horizontal = Input.GetAxisRaw("Horizontal");
                            movement = new Vector2(horizontal, -0.1f);
                            rb.velocity += movement * speed;
                        }
                        else
                        {
                            runAni.Running();
                            horizontal = Input.GetAxisRaw("Horizontal");
                            movement = new Vector2(horizontal, 0f);
                            rb.velocity += movement * speed;
                        }
                    }
                }

                if (Input.GetAxisRaw("Horizontal") < -0.1f)
                {
                    if (centerGrounded)
                    {
                        footSteps.UnPause();
                    }

                    characterBody.flipX = true;
                    if (weapon.transform.position != new Vector3(-1, 0, 0))
                    {
                        weapon.transform.position = playerPos.transform.position + new Vector3(-1, 0, 0);
                    }

                    if (rb.velocity.magnitude < speedLimit)
                    {
                        if (!centerGrounded)
                        {
                            runAni.Running();
                            horizontal = Input.GetAxisRaw("Horizontal");
                            movement = new Vector2(horizontal, -0.1f);
                            rb.velocity += movement * speed;
                        }
                        else
                        {
                            runAni.Running();
                            horizontal = Input.GetAxisRaw("Horizontal");
                            movement = new Vector2(horizontal, 0f);
                            rb.velocity += movement * speed;
                        }
                    }
                }
            }

            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                footSteps.Pause();
                runAni.Idle();
            }


            //Ground check and jump
            if (Input.GetButtonDown("Jump"))
            {
                justJumped = true;
                if (centerGrounded || leftGrounded || rightGrounded)
                {
                    rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
                }

                centerGrounded = false;
            }

            //Falling physics
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMulitplier - 1) * Time.deltaTime;
            }

            if (justJumped && centerGrounded)
            {
                jump.Play();
                Debug.Log("Jump played");
                justJumped = false;
            }
        }
    }

    public void CheckRayCast()
    {
        Vector2 centerRayStart = groundCheck.bounds.center;
        Vector2 leftRayStart = groundCheck.bounds.center;
        Vector2 rightRayStart = groundCheck.bounds.center;

        leftRayStart.x -= groundCheck.bounds.extents.x;
        rightRayStart.x += groundCheck.bounds.extents.x;

        //THIS IS ONLY FOR DEBUGGING
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        Debug.DrawRay(leftRayStart, Vector2.down, Color.red);//-------------------------------------------------------------------------------
        Debug.DrawRay(centerRayStart, Vector2.down, Color.cyan);//-------------------------------------------------------------------------------
        Debug.DrawRay(rightRayStart, Vector2.down, Color.green);//-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------

        if (Physics2D.Raycast(leftRayStart, Vector2.down, (groundCheck.bounds.extents.y + 0.1f)))
        {
            //Debug.Log("is touching ground left");
            leftGrounded = true;
        }
        else
        {
            leftGrounded = false;
        }


        if (Physics2D.Raycast(rightRayStart, Vector2.down, (groundCheck.bounds.extents.y + 0.1f)))
        {
            //Debug.Log("is touching ground right");
            rightGrounded = true;
        }
        else
        {
            rightGrounded = false;
        }

        if (Physics2D.Raycast(centerRayStart, Vector2.down, (groundCheck.bounds.extents.y + 0.1f)))
        {
            //Debug.Log("is touching ground center");
            centerGrounded = true;
        }
        else
        {
            centerGrounded = false;
        }
    }
}
