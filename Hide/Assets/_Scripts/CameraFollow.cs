using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float smoothSpeed = 0.125f;

    public bool lookAt = false;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoorhedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoorhedPosition;

        if (lookAt)
        {

        }
    }
}
