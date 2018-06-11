using UnityEngine;
using UnityEngine.UI;

public class AttackInstruction : MonoBehaviour {

    public Text tutorialText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        tutorialText.text = "Press the \"Left Control\" key, to attack!";
    }
}
