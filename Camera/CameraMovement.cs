using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    private Vector3 positionOffset;
    private Vector3 playerPosition;

    private void Start()
    {
        positionOffset = target.position;
    }

    private void LateUpdate()
    {
        playerPosition = new Vector3(target.position.x, target.position.y, -1);
        offset = new Vector3(positionOffset.x, positionOffset.y+5, -1);

        Vector3 desiredPosition = playerPosition + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}