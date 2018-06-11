using UnityEngine;

public class MapFloor : MonoBehaviour {

    public GameManager gm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gm.RespawnPlayer();
        }
        else if (collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("EnemyDied");
        }
    }
}
