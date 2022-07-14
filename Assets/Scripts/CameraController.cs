using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;

    public GameObject player;

    void Start()
    {
        offset = (transform.position - player.transform.position);
    }
    void FixedUpdate()
    {
        Vector3 targetPosition = player.transform.position + offset;
        Vector3 vel = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, 0.075f);

    }
}
