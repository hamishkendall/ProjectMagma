using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float fallMulitplier;
    public float jumpVelocity;
    private bool isGrounded;
    private float horizontal;
    Rigidbody2D rb;
    Vector2 movement;


    void Start () {

        isGrounded = true;
        jumpVelocity = 5;
        rb = GetComponent<Rigidbody2D>();
        fallMulitplier = 3f;
        speed = 15;
    }

    private void FixedUpdate()
    {
        //moving side to side
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            horizontal = Input.GetAxisRaw("Horizontal");
            movement = new Vector2(horizontal, 0f);
            //rb.AddForce(movement, ForceMode2D.Impulse);
            rb.velocity += movement * speed * Time.deltaTime;
        }


        //Ground check and jump
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //transform.Translate(new Vector3( 0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
                rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            }
        }

        //Falling physics
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMulitplier - 1) * Time.deltaTime;
        }
    }

    //Checking whether the character model is grounded.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            Debug.Log("landed");
        }
    }

    //Checking whether the character model is grounded.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
            Debug.Log("left ground");
        }
    }
}
