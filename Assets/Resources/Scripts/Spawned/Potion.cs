using System;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private float verticalSpeed = 0.2f;
    private float verticalLimit = 0.3f;
    private float rotationSpeed = 8f;

    private Vector3 defaultPosition;
    private bool goingUp;

    private void Awake()
    {
        defaultPosition = transform.position;
        goingUp = true;
    }
    private void Update()
    {
        if (goingUp)
        {
            if (transform.position.y < defaultPosition.y + verticalLimit) gameObject.transform.position += new Vector3(0, verticalSpeed * Time.deltaTime, 0);
            else goingUp = false;
        }
        else if (!goingUp)
        {
            if (transform.position.y > defaultPosition.y - verticalLimit) gameObject.transform.position += new Vector3(0, -verticalSpeed * Time.deltaTime, 0);
            else goingUp = true;
        }

        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
}

