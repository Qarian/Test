using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    
    [SerializeField] private float maxAngle = 60;
    
    private float currentRotation = 0;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        currentRotation += mouseY * -speed * Time.deltaTime;
        currentRotation = Mathf.Clamp(currentRotation, -maxAngle, maxAngle);

        //transform.rotation = quaternion.Euler(currentRotation, 0,0);
        transform.Rotate(mouseY * -speed * Time.deltaTime,0,0);
        transform.parent.Rotate(0, mouseX * speed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;
        }
    }
}
