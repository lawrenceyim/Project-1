using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;       // Horizontal movement speed
    [SerializeField] private float acceleration;    // Horizontal acceleration
    [SerializeField] private float deceleration;    // Horizontal deceleration
    [SerializeField] private float maxSpeed;        // Maximum horizontal speed
    [SerializeField] private float jumpForce;       
    private float playerHeight;                     
    private float playerWidth;                      
    private Rigidbody2D rb;
    [SerializeField] private bool canJump;         
    [SerializeField] private bool canDoubleJump;   
    [SerializeField] private float jumpGracePeriod;
    [SerializeField] private bool graceTimerStarted;
    [SerializeField] private float cantJumpAt;
    private Vector3 leftRaycastOrigin;              // Used to determine if the player is grounded
    private Vector3 rightRaycastOrigin;             // Used to determine if the player is grounded
    [SerializeField] private GameObject teleportationFlag;
    [SerializeField] private bool flagPlaced;
    [SerializeField] private float teleportIn;
    [SerializeField] private float teleportTimer;
    private GameObject placedFlag;
    private Animator animator;

    void Start()
    {
        Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
        canDoubleJump = true;
        playerHeight = transform.localScale.y;
        playerWidth = transform.localScale.x;
    }

    /*
    Player input detection has been moved to Update instead of FixedUpdate to improve consistency
    */
    private void Update() {
        Run();
        Jump();
        Teleport();
    }

    void FixedUpdate()
    {
        if (IsGrounded()) {
            animator.SetBool("IsGrounded", true);
            if (IsNotOverHazard()) {
                canJump = true;
                canDoubleJump = true;
                graceTimerStarted = false;
            }
        } else if (canJump) {
            animator.SetBool("IsGrounded", false);
            if (!graceTimerStarted) {
                cantJumpAt = Time.time + jumpGracePeriod;
                graceTimerStarted = true;
            } else if (graceTimerStarted && Time.time >= cantJumpAt) {
                canJump = false;
                graceTimerStarted = false;
            }
        }  
    }

    void Run() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float currentVelocity = rb.velocity.x;
        // Acceleration and deceleration
        if (horizontalInput != 0)
        {   Vector3 scale = transform.localScale;
            if (horizontalInput > 0) {
                scale.x = Mathf.Abs(scale.x);
            } else {
                scale.x = -Mathf.Abs(scale.x);
            }
            transform.localScale = scale;

            animator.SetBool("Moving", true);
            float targetVelocity = Mathf.Clamp(horizontalInput * moveSpeed, -maxSpeed, maxSpeed);
            float accelerationValue = (horizontalInput * moveSpeed >= currentVelocity) ? acceleration : deceleration;
            rb.velocity = new Vector2(Mathf.MoveTowards(currentVelocity, targetVelocity, accelerationValue * Time.deltaTime), rb.velocity.y);
        }
        else
        {
            animator.SetBool("Moving", false);
            rb.velocity = new Vector2(Mathf.MoveTowards(currentVelocity, 0f, deceleration * Time.deltaTime), rb.velocity.y);
        }
    }

    void Jump() {
        /* 
        [OUTDATED] Input.GetButton is used instead of Input.GetButtonDown because the latter was inconsistent. The 
        character didn't always jump when the button was pressed.
        A problem that occurred with Input.GetButton was that the player would jump twice with one press because the 
        player didn't let go off the key fast enough, resulting in wasted jump opportunities. To compensate for this problem,
        a jump cooldown was added to stop the player from accidentally jumping twice in a row.
        */
        if (Input.GetButtonDown("Jump")) {
            if (canJump || canDoubleJump) {
                animator.SetBool("IsGrounded", false);
                Vector2 currentVelocity = rb.velocity;
                currentVelocity.y = 0f;
                rb.velocity = currentVelocity;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                if (canJump) {
                    canJump = false;
                } else {
                    canDoubleJump = false;
                }
            }
        }
    }

    bool IsGrounded() {
        leftRaycastOrigin = transform.position;
        leftRaycastOrigin.x -= playerWidth / 2;
        rightRaycastOrigin = transform.position;
        rightRaycastOrigin.x += playerWidth / 2;
        
        RaycastHit2D leftHit = Physics2D.Raycast(leftRaycastOrigin, Vector2.down, playerHeight * 1.7f, LayerMask.GetMask("Terrain"));
        RaycastHit2D rightHit = Physics2D.Raycast(rightRaycastOrigin, Vector2.down, playerHeight * 1.7f, LayerMask.GetMask("Terrain"));

        if (leftHit != null && leftHit.collider != null) return true;
        if (rightHit != null && rightHit.collider != null) return true;
        return false;
    }

    bool IsNotOverHazard(){
        leftRaycastOrigin = transform.position;
        leftRaycastOrigin.x -= playerWidth / 2;
        rightRaycastOrigin = transform.position;
        rightRaycastOrigin.x += playerWidth / 2;

        RaycastHit2D leftDeathHit = Physics2D.Raycast(leftRaycastOrigin, Vector2.down, playerHeight * 1.7f, LayerMask.GetMask("Hazard"));
        RaycastHit2D rightDeathHit = Physics2D.Raycast(rightRaycastOrigin, Vector2.down, playerHeight * 1.7f, LayerMask.GetMask("Hazard"));

        if(leftDeathHit != null && leftDeathHit.collider != null) return false; 
        if(rightDeathHit != null && rightDeathHit.collider != null) return false; 
        return true; 
    }

    void Teleport() {
        if (Input.GetKey("e") && !flagPlaced) {
            PlaceTeleportationFlag();
        }        
        if (!flagPlaced) return;
        if (Time.time >= teleportIn) {
            transform.position = placedFlag.transform.position;
            Destroy(placedFlag);
            flagPlaced = false;
        }
    }

    void PlaceTeleportationFlag() {
        placedFlag = Instantiate(teleportationFlag, transform.position, Quaternion.identity);
        flagPlaced = true;
        teleportIn = Time.time + teleportTimer;
    }
}
