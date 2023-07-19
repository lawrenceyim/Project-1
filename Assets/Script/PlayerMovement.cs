using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;       // Horizontal movement speed
    [SerializeField] private float acceleration;  // Horizontal acceleration
    [SerializeField] private float deceleration;  // Horizontal deceleration
    [SerializeField] private float maxSpeed;       // Maximum horizontal speed

    [SerializeField] private float jumpForce;     // Jump force
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float jumpAvailableAt;
    private float playerHeight;   // Height of the player
    private float playerWidth; // Width of the player 

    private Rigidbody2D rb;
    private float originalGravityScale;
    [SerializeField] private bool canJump;
    [SerializeField] private bool canDoubleJump;
    private Vector3 leftRaycastOrigin;
    private Vector3 rightRaycastOrigin;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravityScale = rb.gravityScale;
        canJump = true;
        jumpAvailableAt = Time.time;
        playerHeight = transform.localScale.y;
        playerWidth = transform.localScale.x;

    }

    private void Update() {

    }

    void FixedUpdate()
    {
        if (!canJump && IsGrounded()) {
            jumpAvailableAt = Time.time;
            canJump = true;
            canDoubleJump = true;
        }
        Run();
        Jump();
    }

    void Run() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float currentVelocity = rb.velocity.x;
        // Acceleration and deceleration
        if (horizontalInput != 0)
        {
            float targetVelocity = Mathf.Clamp(horizontalInput * moveSpeed, -maxSpeed, maxSpeed);
            float accelerationValue = (horizontalInput * moveSpeed >= currentVelocity) ? acceleration : deceleration;
            rb.velocity = new Vector2(Mathf.MoveTowards(currentVelocity, targetVelocity, accelerationValue * Time.deltaTime), rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(Mathf.MoveTowards(currentVelocity, 0f, deceleration * Time.deltaTime), rb.velocity.y);
        }
    }

    void Jump() {
        if (Input.GetButton("Jump")) {
            if (Time.time < jumpAvailableAt) {
                return;
            }
            if (canJump || canDoubleJump) {
                Vector2 currentVelocity = rb.velocity;
                currentVelocity.y = 0f;
                rb.velocity = currentVelocity;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                if (canJump) {
                    canJump = false;
                } else {
                    canDoubleJump = false;
                }
                jumpAvailableAt = Time.time + jumpCooldown;
            }
        }
    }

    bool IsGrounded() {
        leftRaycastOrigin = transform.position;
        leftRaycastOrigin.x -= playerWidth / 2;
        rightRaycastOrigin = transform.position;
        rightRaycastOrigin.x += playerWidth / 2;
        
        RaycastHit2D leftHit = Physics2D.Raycast(leftRaycastOrigin, Vector2.down, playerHeight * 0.6f, LayerMask.GetMask("Terrain"));
        RaycastHit2D rightHit = Physics2D.Raycast(rightRaycastOrigin, Vector2.down, playerHeight * 0.6f, LayerMask.GetMask("Terrain"));

        if (leftHit != null && leftHit.collider != null) return true;
        if (rightHit != null && rightHit.collider != null) return true;
        return false;
    }
}
