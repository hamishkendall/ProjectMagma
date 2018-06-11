using UnityEngine;
using UnityEngine.UI;

public class SpawnText: MonoBehaviour {

    public Text tutorialText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        tutorialText.text = "Press \"A\" and \"D\" or Left and Right arrows keys to move. ";
    }
}
