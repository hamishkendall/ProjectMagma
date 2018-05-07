using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float fallMulitplier;
    public float jumpVelocity;
    private float horizontal;
    private Rigidbody2D rb;
    private Vector2 movement;
    private BoxCollider2D groundCheck;
    public bool centerGrounded, leftGrounded, rightGrounded;
    private float speedLimit;


    void Start () {
        speedLimit = 20f;
        centerGrounded = false; 
        rightGrounded = false; 
        leftGrounded = false;
        jumpVelocity = 12;
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<BoxCollider2D>();
        fallMulitplier = 6f;
        speed = 2f;
    }

    private void FixedUpdate()
    {

        CheckRayCast();

        //moving side to side
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            if(rb.velocity.magnitude < speedLimit)
            {
                horizontal = Input.GetAxisRaw("Horizontal");
                movement = new Vector2(horizontal, 0f);
                rb.velocity += movement * speed;
            }
        }


        //Ground check and jump
        if (Input.GetButtonDown("Jump"))
        {
            if (centerGrounded || leftGrounded || rightGrounded)
            {
                rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            }
        }

        //Falling physics
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMulitplier - 1) * Time.deltaTime;
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

        if (Physics2D.Raycast(leftRayStart, Vector2.down, (groundCheck.bounds.extents.y + 0.2f)))
        {
            Debug.Log("is touching ground left");
            leftGrounded = true;
        }
        else
        {
            leftGrounded = false;
        }


        if (Physics2D.Raycast(rightRayStart, Vector2.down, (groundCheck.bounds.extents.y + 0.2f)))
        {
            Debug.Log("is touching ground right");
            rightGrounded = true;
        }
        else
        {
            rightGrounded = false;
        }

        if (Physics2D.Raycast(centerRayStart, Vector2.down, (groundCheck.bounds.extents.y + 0.2f)))
        {
            Debug.Log("is touching ground center");
            centerGrounded = true;
        }
        else
        {
            centerGrounded = false;
        }
    }
}
