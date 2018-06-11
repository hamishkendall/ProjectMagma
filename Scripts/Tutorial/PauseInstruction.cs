using UnityEngine;
using UnityEngine.UI;

public class PauseInstruction : MonoBehaviour {

    public Text tutorialText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        tutorialText.text = "Press the \"Esc\" key to pause the game";
    }
}
