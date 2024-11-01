using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollower : MonoBehaviour
{

    // The transform of the game object the camera will target.
    [SerializeField] private Transform target;

    // The offset at which we look at the target.
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);

    // The damping value to follow the target with. Smaller values result in closer following.    
    [SerializeField, Range(0, 1)] private float smoothness;

    [SerializeField] private bool followPlayerDefault = false;

    public bool FollowPlayer
    {
        get { return followPlayerDefault; }
        set { followPlayerDefault = value; }
    }

    // The 3D zero vector as a variable.    
    private Vector3 zeroVector = Vector3.zero;

    // The final position to which the camera moves after the offset.    
    private Vector3 targetPos;


    private void Update()
    {
        UpdatePosition();
    }

    // Updates the camera's position towards the target.
    private void UpdatePosition()
    {
        if (followPlayerDefault)
        {
            // apply any offset
            targetPos = target.position + offset;
        }
        else
        {
            targetPos = Vector3.zero + offset;
        }

        // ensures z value is 0
        targetPos = new Vector3(targetPos.x, targetPos.y, offset.z);

        // smooth the position to a new variable
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPos, ref zeroVector, smoothness);

        // set our position to the smoothed position
        transform.position = smoothedPosition;
    }
}
