using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            new Vector3(
                target.position.x,
                target.position.y,
                transform.position.z
                ),
            Time.deltaTime
            );
    }
}
