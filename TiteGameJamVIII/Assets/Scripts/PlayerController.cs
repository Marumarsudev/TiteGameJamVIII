﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1f;

    public float hunger = 100f;
    public float thirst = 100f;

    private Rigidbody2D body;
    private Animator animator;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.GetMovement() != Vector2.zero)
        {
            animator.SetBool("Movement", true);
            body.AddForce(movementSpeed * InputManager.GetMovement(), ForceMode2D.Impulse);
            if(body.velocity.magnitude > movementSpeed)
                body.velocity = body.velocity.normalized * movementSpeed;
        }
        else
        {
            animator.SetBool("Movement", false);
            body.velocity = Vector2.zero;
        }

        if (body.velocity.y < 0f) // Going Down
        {
            animator.SetInteger("Direction", 0);
        }
        else if (body.velocity.y > 0f) // Going Up
        {
            animator.SetInteger("Direction", 1);
        }
        
        if (body.velocity.x != 0f) // Going Sideways
        {
            animator.SetInteger("Direction", 2);
            if(body.velocity.x < 0f)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
    }
}
