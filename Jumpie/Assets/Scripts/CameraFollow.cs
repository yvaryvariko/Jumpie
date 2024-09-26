using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTransform;
    [SerializeField] private float smoothFollowValue;
    public Vector3 offset;

    
    void Update()
    {
        Vector3 desiredPosition = new Vector3(transform.position.x, playerTransform.position.y + offset.y, transform.position.z);

        Vector3 smoothFollow = Vector3.Lerp(transform.position, desiredPosition, smoothFollowValue);

        transform.position = smoothFollow;

    }
}
