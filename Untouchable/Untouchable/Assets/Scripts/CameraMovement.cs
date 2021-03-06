﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public string mouseXInputName, mouseYInputName;
    public float mouseSensitivity;
    private float mouseX;
    private float mouseY;
    private float xAxisClamp = 0;

    void Awake()
    {
        LookCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInParent<Movement>().canMove)
        {
            CameraRotation();
            GetComponent<Animator>().enabled = false;
        }
    }

    private void LookCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void CameraRotation()
    {
        mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 60)
        {
            xAxisClamp = 60;
            mouseY = 0;
            ClampXAxisRotation(270);
        }
        else if (xAxisClamp < -60)
        {
            xAxisClamp = -60;
            mouseY = 0;
            ClampXAxisRotation(60);
        }

        transform.Rotate(Vector3.left * mouseY);
        player.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotation(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
