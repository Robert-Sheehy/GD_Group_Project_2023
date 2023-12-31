using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KCameraMovement : MonoBehaviour
{
    public float desiredAngle = 0;
    private float bufferZone = 2;

    private float sensitivity = 90f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1))
        {
            desiredAngle += sensitivity * Input.GetAxis("Horizontal") * Time.deltaTime;

            desiredAngle = Mathf.Clamp(desiredAngle, -179f, 179f);
        }

        if (angleIsTooSmall())
        {

            transform.RotateAround(transform.parent.position, Vector3.up, 1);
        }
        else
            if (angleIsTooBig())

        {

            transform.RotateAround(transform.parent.position, Vector3.up, -1);
        }



        desiredAngle = Mathf.Lerp(desiredAngle, 0, 0.001f);


    }

    private bool angleIsTooBig()
    {
        float angle = adjustAngle180(transform.localRotation.eulerAngles.y);
        return angle > desiredAngle + bufferZone;
    }

    private bool angleIsTooSmall()
    {
        float angle = adjustAngle180(transform.localRotation.eulerAngles.y);
        return angle < desiredAngle - bufferZone;
    }

    float adjustAngle180(float angle)
    {
        if (Mathf.Abs(angle) <= 180f) return angle;

        if (angle > 180f) return adjustAngle180(angle - 360f);
        return adjustAngle180(angle + 360f);

    }
}
