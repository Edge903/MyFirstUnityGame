using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 0f, -3f);
    // public float smoothTime = 0.1f;

    // private Vector3 velocity;

    
    void LateUpdate()
    {
        if (target == null) return;
        
        // Position
        // Vector3 desiredPosition = target.TransformPoint(offset);
        // transform.position = Vector3.SmoothDamp(
        //     transform.position,
        //     desiredPosition,
        //     ref velocity,
        //     smoothTime
        // );

        transform.position = target.TransformPoint(offset);

        // Rotation
        transform.rotation = target.rotation;

    }

}
