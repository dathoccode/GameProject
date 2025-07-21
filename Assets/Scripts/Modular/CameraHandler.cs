using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraHandler : MonoBehaviour
{
    GameObject target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        FollowTarget(target.transform.position);
    }

    private void FollowTarget(Vector3 targetPosition)
    {
        if (target == null) return;

        Vector3 newPosition = targetPosition;
        newPosition.z = -10; // Set the camera's z position to -10 to avoid clipping
        transform.position = newPosition;
    }
}