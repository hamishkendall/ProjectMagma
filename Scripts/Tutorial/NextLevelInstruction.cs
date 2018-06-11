using UnityEngine;
using UnityEngine.UI;

public class NextLevelInstruction : MonoBehaviour {

    public Text tutorialText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        tutorialText.text = "Tutorial COMPLETE! Jump into the water, to move to the next level!";
    }
}
