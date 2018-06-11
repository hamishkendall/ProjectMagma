using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    private Vector3 positionOffset;
    private Vector3 playerPosition;
    private float nextTimeToSearch = 0;

    private void Start()
    {
        positionOffset = target.position;
    }

    private void LateUpdate()
    {
        /*if(target == null)
        {
            FindPlayer();
            return;
        }*/

        playerPosition = new Vector3(target.position.x, target.position.y, -1);
        offset = new Vector3(positionOffset.x, positionOffset.y+1, -1);

        Vector3 desiredPosition = playerPosition + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    public void FindPlayer()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            
            if(searchResult != null)
            {
                target = searchResult.transform;
            }
            nextTimeToSearch = Time.time + 0.5f;
        }
    }
}