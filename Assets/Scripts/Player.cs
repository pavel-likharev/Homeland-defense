using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;


    Vector2 moveInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    Rigidbody2D myRigidbody;
    Shooter shooter;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        InitBounds();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InitBounds()
    {
        Camera cam = Camera.main;
        minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));
    }
    void Move()
    {
        myRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
