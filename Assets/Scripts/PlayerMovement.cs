using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
<<<<<<< Updated upstream


    private Vector2 moveDirection;
    public SpriteRendererScript spriteRendererScript;
=======
    private Vector2 moveDirection;
    
>>>>>>> Stashed changes

    void Awake()
    {
        spriteRendererScript = GetComponent<SpriteRendererScript>();
    }
    void Update()
    {
        ProcessInputs();
<<<<<<< Updated upstream
        Vector3 scale = transform.localScale;
        if (moveDirection.x > 0)
        {
            scale.x = Mathf.Abs(transform.localScale.x);
        }
        else if (moveDirection.x != 0)
        {
            scale.x = Mathf.Abs(transform.localScale.x) * -1;
        }

        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            spriteRendererScript.isRunning = true;
            spriteRendererScript.isIdling = false;
        }
        else
        {
            spriteRendererScript.isRunning = false;
            spriteRendererScript.isIdling = true;
        }
        transform.localScale = scale;

=======
        
>>>>>>> Stashed changes
    }

    void FixedUpdate()
    {
        Move();
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

<<<<<<< Updated upstream
        moveDirection = new Vector2(moveX, moveY);
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
=======
        
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed  , moveDirection.y * moveSpeed);
       
>>>>>>> Stashed changes
    }

}
