using UnityEngine;

public class Attack : MonoBehaviour {

    public int damage;
    public bool isAttacking;
    public float attackDisplayTimer, attackTimer;
    public PlayerDetails pDets;
    public Collider2D weaponCollider;
    public AnimationHandler attackAni;
    public PlayerMovement direction;
    public Vector2 currentPos, leftPos, rightPos;
    public AudioSource attack, attackHit;

	// Use this for initialization
	void Start () {
        //change damage numbers to possible damage from PlayerDetails later
        attackDisplayTimer = 0.3f;
        attackTimer = 0f;
        isAttacking = false;
        damage = pDets.GetPlayerDamage();
        weaponCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            weaponCollider.enabled = true;
            KeyPressRegistered();

            if (!attack.isPlaying)
            {
                attack.Play();
            }

            isAttacking = true;

            attackAni.Attacking();
            attackTimer = attackDisplayTimer;
        }

        if (isAttacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                weaponCollider.enabled = false;
                isAttacking = false;
                attackAni.Idle();
            }
        }
    }

    public bool KeyPressRegistered()
    {
        return true;
    }

    public bool DamageSent()
    {
        return true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger && other.CompareTag("Enemy"))
        {
            damage = pDets.GetPlayerDamage();
            other.SendMessageUpwards("EnemyTookDamage", damage);
            DamageSent();
            Debug.Log("attacked");

            if (!attackHit.isPlaying)
            {
                attackHit.Play();
            }
        }  
    }
}
