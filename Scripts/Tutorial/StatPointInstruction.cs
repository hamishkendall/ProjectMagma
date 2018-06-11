using UnityEngine;
using UnityEngine.UI;

public class StatPointInstruction : MonoBehaviour {

    public Text tutoritalText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        tutoritalText.text = "You received stat points for leveling up! Click the Up or Down arrow on the corrosponding stat you wish to invest in!";
    }
}
