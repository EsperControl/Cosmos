﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] float cruiseSpeed = 1f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float acceleration = 1f;
    [SerializeField] float decceleration = 1f;
    [SerializeField] float stabilisation = 1f;
    [SerializeField] bool controled = true;
    [SerializeField] int ControlScheme = 0;


    PlayerInput input;                      //The current inputs for the player
    BoxCollider2D bodyCollider;             //The collider component
    Rigidbody2D rigidBody;					//The rigidbody component
    float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        float rotation = input.horizontal;
        float throttle = cruiseSpeed * input.throttle;
        if (throttle > 0)
        {
            speed += acceleration * throttle;
        }else if (throttle < 0)
        {
            speed += decceleration * throttle;
        }
        else
        {
            if (speed > 0)
            {
                speed -= stabilisation;
            }else if (speed < 0)
            {
                speed += stabilisation;
            }
        }
        speed = Mathf.Clamp(speed, -cruiseSpeed/2, cruiseSpeed);
        rigidBody.angularVelocity = rotation * rotationSpeed;
        float cos = Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad);
        float sin = Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad);
        Vector2 velocity = new Vector2(-sin, cos);
        rigidBody.velocity = velocity*speed;
    }

}
