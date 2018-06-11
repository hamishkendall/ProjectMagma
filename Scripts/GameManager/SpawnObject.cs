using UnityEngine;

public class SpawnObject : MonoBehaviour {
    //the chest area is depending on the size of the game level and the center location
    public Vector2 center;
    public Vector2 size;
    [SerializeField] ItemChest itemChest;

    public void SpawnItemChest()
    {
        Vector2 position = center + new Vector2(Random.Range(-size.x / 2, size.x / 2), (Random.Range(-size.y / 2, size.y / 2)));
        Instantiate(original: itemChest, position: position, rotation: Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(center, size);
    }
    public Vector2 LeftArea(Vector2 center, Vector2 size)
    {
        Vector2 area = center - (size/2);
       

        return area;
    }

    public Vector2 RightArea(Vector2 center, Vector2 size)
    {
        Vector2 area = center + (size / 2.00f);


        return area;
    }
}
