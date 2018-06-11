using UnityEngine;
using UnityEngine.UI;

public class LootChestInstruction : MonoBehaviour {

    public Text tutorialText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        tutorialText.text = "Press \"E\" to open loot chests. Items are added directly to inventory!";
    }
}
