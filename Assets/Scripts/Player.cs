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
    

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        
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

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Move()
    {
        myRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
    }
}
