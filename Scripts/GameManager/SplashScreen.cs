using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

    public AudioSource splashSound;
    public float timeToWait = 3f;

    private void Update()
    {
        timeToWait -= Time.deltaTime;

        if(timeToWait <= 0)
        {
            if (!splashSound.isPlaying)
            {
                Debug.Log(!splashSound.isPlaying);
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
