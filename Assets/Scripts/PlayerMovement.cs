﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharController controller;

    public float runSpeed = 40f;
    float DirX = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        DirX = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump")) jump = true;
        if (Input.GetButtonDown("Crouch")) crouch = true;
        else if (Input.GetButtonUp("Crouch")) crouch = false;
    }

    private void FixedUpdate()
    {
        controller.Move(DirX * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
