using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float height;
    public float step=10f;

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 10.0f;

    private float currentX = 0.0f;



    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            currentX -= step;
        }
        if (Input.GetKey(KeyCode.E))
        {
            currentX += step;
        }
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(height, currentX, 0);
        transform.position = lookAt.position + rotation * dir;
        transform.LookAt(lookAt.position);
    }
}
