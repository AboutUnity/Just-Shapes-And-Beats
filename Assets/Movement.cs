using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float speed;
    public float dashDistance;
    float moveX;
    float moveY;
    private Vector3 moveDirection;
    bool isDashButtonDown = false;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(moveX, moveY).normalized;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDashButtonDown = true;
        }


    }
    public void FixedUpdate()
    {
        rb.velocity = ToVector2(moveDirection) * speed;
        if (isDashButtonDown)
        {
            rb.MovePosition(transform.position + moveDirection * dashDistance);
            isDashButtonDown = false;
        }
    }
    public Vector2 ToVector2(Vector3 input)
    => new Vector2(input.x, input.y);
}
