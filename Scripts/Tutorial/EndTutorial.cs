using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutorial : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
