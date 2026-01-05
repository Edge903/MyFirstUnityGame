using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); //ad
        float z = Input.GetAxisRaw("Vertical"); //ws

        moveInput = new Vector3(x, 0f, z).normalized;
    }

    void FixedUpdate()
    {
        Vector3 velocity = moveInput * moveSpeed;
        Vector3 newPosition = rb.position + velocity * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }
}
