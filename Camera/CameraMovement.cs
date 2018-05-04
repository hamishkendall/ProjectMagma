using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    private Vector3 positionOffset;
    private Vector3 playerPosition;


    //THIS METHOD 
    private void Start()
    {
        positionOffset = target.position;
    }

    
    //THIS METHOD IS RUN EVERY FRAME, AFTER THE UPDATE METHOD.
    //This method is checking the players position in the game, checking the cameras position, applying an offset value and then LERPING the camera to the players position.
    private void LateUpdate()
    {
        playerPosition = new Vector3(target.position.x, target.position.y, -1);
        offset = new Vector3(positionOffset.x, positionOffset.y+5, -1);

        Vector3 desiredPosition = playerPosition + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}