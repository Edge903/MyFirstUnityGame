using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Jump")]
    public float jumpForce = 6f;
    public float groundCheckDistance = 0.15f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private Vector3 moveInput;
    private bool jumpRequested;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement
        float x = Input.GetAxisRaw("Horizontal"); //ad
        float z = Input.GetAxisRaw("Vertical"); //ws

        moveInput = new Vector3(x, 0f, z).normalized;

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequested = true;
            Debug.Log("jump input");
        }

    }

    void FixedUpdate()
    {
        // Movement
        Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.z;
        Vector3 velocity = moveDirection * moveSpeed;
        Vector3 newPosition = rb.position + velocity * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);

        // Jump
        if (jumpRequested && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("jump applied");
        }
        jumpRequested = false;

    }

    bool IsGrounded ()
    {
        CapsuleCollider col = GetComponent<CapsuleCollider>();

        Vector3 origin = col.bounds.center;
        float rayLength = col.bounds.extents.y + groundCheckDistance;

        return Physics.Raycast(
            origin,
            Vector3.down,
            rayLength,
            groundLayer
        );
    }

}
