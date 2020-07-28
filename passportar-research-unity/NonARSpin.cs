using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonARSpin : MonoBehaviour
{
    public float spinspeed = 10f;
    private Touch touch; //Finger rotation concept from https://www.youtube.com/watch?v=7Ja67KpKLXw (01.07.2020)
    private Vector2 touchPosition;
    private Quaternion rotationY, rotationX, rotationZ;
    private float rotateSpeed = 0.1f;

    void Update()
    {
        transform.Rotate(Vector3.up, spinspeed * Time.deltaTime, Space.World);

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                rotationY = Quaternion.Euler(
                    0f,
                    -touch.deltaPosition.x * rotateSpeed,
                    0f);

                rotationX = Quaternion.Euler(
                   touch.deltaPosition.y * rotateSpeed, 
                   0f,                 
                   0f);

                transform.rotation = rotationY * rotationX * transform.rotation;             
            }           
        }
    }
}
