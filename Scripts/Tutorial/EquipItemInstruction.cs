using UnityEngine;
using UnityEngine.UI;

public class EquipItemInstruction : MonoBehaviour {

    public Text tutorialText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        tutorialText.text = "While inventory is open, click on the item to equip it";
    }
}
