using UnityEngine;

/*
 * Author: Omar Samu
 * Last Modified: 4/224/2025
 * Description: Allows the camera to follow Ninja along a track smoothly.
*/

public class SmoothCamera : MonoBehaviour
{
    Transform camTarget;
    Transform lookAt;
    [SerializeField][Range(0f, 100f)] float moveLerpSpeed;
    [SerializeField][Range(0f, 100f)] float rotateLerpSpeed;

    void Start()
    {
        Transform plr = GameObject.FindWithTag("Player").transform;
        camTarget = plr.GetChild(2);
        lookAt = plr.GetChild(1);
    }

    // Use both updates to prevent jittering.
    void Update() { UpdateCam(); }
    void FixedUpdate() { UpdateCam(); }

    void UpdateCam()
    {
        Vector3 targetPos = new Vector3(0, camTarget.position.y, camTarget.position.z);

        RaycastHit hit;
        Vector3 direction = targetPos - camTarget.position; // Direction from player to camera
        float maxDistance = direction.magnitude; // Max allowable distance

        if (Physics.Raycast(camTarget.position, direction.normalized, out hit, maxDistance))
        {
            // If an obstacle is detected, set the camera position to the hit point
            transform.position = hit.point;
        }
        else
        {
            // No obstacle detected, move camera normally
            transform.position = Vector3.Lerp(transform.position, targetPos, moveLerpSpeed * Time.fixedDeltaTime);
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, moveLerpSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(lookAt.position - transform.position, Vector3.up),
            rotateLerpSpeed * Time.fixedDeltaTime);
    }
}