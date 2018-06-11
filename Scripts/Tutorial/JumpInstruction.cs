using UnityEngine;
using UnityEngine.UI;

public class JumpInstruction : MonoBehaviour {

    public Text tutorialText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        tutorialText.text = "Press \"Space Bar\" to jump. You can change your direction whilst in the air";
    }
}
