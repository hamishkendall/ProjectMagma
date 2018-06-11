using UnityEngine;
using UnityEngine.UI;

public class PickUpInstruction : MonoBehaviour {

    public Text tutorialText;
    public EnemyAI enemy;
    private bool enemyKilled = false;
    public GameObject item;

    private void Update()
    {
        item = GameObject.FindGameObjectWithTag("Item");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (enemyKilled && item != null)
        {
            tutorialText.text = "Press the\"X\" key to pick up the item.";
        }

        if(enemy == null)
        {
            enemyKilled = true;
            
        }

        if (enemyKilled && item == null)
        {
            tutorialText.text = "Press the \"I\" key to open the inventory.";
        }
    }
}
