using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset; //saves the position of the camera relative to the player
    [SerializeField] GameObject player;

    void Start()
    {
        offset = (transform.position - player.transform.position);
    }

    void FixedUpdate()
    {
        //Keep the camera position on the same offset from player
        Vector3 targetPosition = player.transform.position + offset;
        Vector3 vel = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, 0.075f);
    }
}
