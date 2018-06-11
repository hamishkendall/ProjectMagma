using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public Enemy enemy;
    public Text monName, monHp;
    private Rigidbody2D rb;
    private Vector2 leftMove, rightMove;
    private bool isMovingLeft, isGrounded;
    private float speed, health, maxHealth, fallMulitplier;
    public GameManager gm;
    public int damage, exp;
    private Random random;
    public Image healthBar;
    public Collider2D groundCheck;
    public GameObject[] items;
    public GameObject objectToDestory;
    public PlayerDetails pDets;
    public UIManager uiMan;


    void Start () {
        monName.text = enemy.name;
        rb = GetComponent<Rigidbody2D>();
        leftMove = new Vector2(-1, 0);
        rightMove = new Vector2(1, 0);
        isMovingLeft = false;
        speed = 0.5f;
        damage = enemy.damagePossible;
        health = enemy.heath;
        maxHealth = enemy.heath;
        fallMulitplier = 6f;
        isGrounded = false;
        exp = enemy.expReward;
    }
	
	// Update is called once per frame
	void Update () {
        GroundCheck();

        if (isGrounded)
        {
            MoveAI();
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMulitplier - 1) * Time.deltaTime;
        }
    }

 
    private void MoveAI()
    {
        if (isMovingLeft)
        {
            rb.velocity += leftMove * speed;
        }
        else
        {
            rb.velocity += rightMove * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Flag")
        {
            if (isMovingLeft)
            {
                rb.AddForce(rightMove);
                isMovingLeft = false;
            }
            else
            {
                rb.AddForce(leftMove);
                isMovingLeft = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            int rngDmg = Random.Range((damage - 5), (damage + 5));
            gm.PlayerWasHit(rngDmg);
        }
    }

    public void EnemyTookDamage(int damage)
    {
        health -= damage;
        UpdateHealth();

        if (isMovingLeft)
        {
            transform.Translate(0,0,0);
            rb.AddForce(new Vector2(10, 10), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(-10, 10), ForceMode2D.Impulse);
        }

        if(health <= 0)
        {
            EnemyDied();
        }
        
    }

    public void UpdateHealth()
    {
        healthBar.fillAmount = (health / maxHealth);
        monHp.text = "HP: " + (health / maxHealth)*100 + "% - " + maxHealth;
    }

    private void GroundCheck()
    {
        Vector2 centerRayStart = groundCheck.bounds.center;

        if (Physics2D.Raycast(centerRayStart, Vector2.down, (groundCheck.bounds.extents.y + 0.2f)))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void EnemyDied()
    {
        GameObject itemDropped = Instantiate(items[Random.Range(0, items.Length)], transform.position, transform.rotation) as GameObject;
        Destroy(objectToDestory);
        pDets.AddExp(exp);
        uiMan.UpdateExp();
        uiMan.UpdateLevel();
        expSent(exp);
    }

    public void pauseAi()
    {
        this.speed = 0f;
    }

    public void resumeAi()
    {
        this.speed = 0.5f;
    }

    public int expSent(int exp)
    {
        return exp;
    }
}
