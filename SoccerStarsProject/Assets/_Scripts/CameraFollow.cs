using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        //transform.position = player.position;
        transform.position = new Vector3(player.position.x+offset.x, transform.position.y, transform.position.z);
    }
}
