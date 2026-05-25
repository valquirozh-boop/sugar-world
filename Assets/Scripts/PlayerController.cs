using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 12f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance = 0.12f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Float")]
    [SerializeField] private float floatSmoothTime = 2.5f;
    [SerializeField] private float floatMaxSpeed = 6f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded;
    private bool isFloating;
    private float moveInput;
    private bool facingRight = true;
    private bool isDefeated = false;
    private Transform floatTarget;
    private Vector2 floatVelocity;

    public bool IsGrounded => isGrounded;
    public bool IsMoving => Mathf.Abs(moveInput) > 0.01f;
    public bool InAir => isFloating || !isGrounded || rb.linearVelocity.y > 0.05f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        GetComponent<CircleCollider2D>().sharedMaterial = new PhysicsMaterial2D { friction = 0f, bounciness = 0f };
        if (groundCheck == null)
            groundCheck = transform.Find("GroundCheck");
        if (groundLayer.value == 0)
            groundLayer = LayerMask.GetMask("Default", "Ground");
    }

    private void Update()
    {
        if (isDefeated || isFloating) return;
        var kb = Keyboard.current;
        if (kb == null) return;

        moveInput = 0f;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed)  moveInput = -1f;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) moveInput =  1f;

        bool jumpPressed = kb.spaceKey.wasPressedThisFrame
                        || kb.wKey.wasPressedThisFrame
                        || kb.upArrowKey.wasPressedThisFrame;

        if (jumpPressed && isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        HandleFlip();
    }

    private void FixedUpdate()
    {
        if (isDefeated) return;

        if (isFloating && floatTarget != null)
        {
            isGrounded = false;
            var targetPos = (Vector2)floatTarget.position;
            var newPos = Vector2.SmoothDamp(rb.position, targetPos, ref floatVelocity, floatSmoothTime, floatMaxSpeed);
            rb.MovePosition(newPos);
            return;
        }

        isGrounded = groundCheck != null
            && Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    public void StartFloat(Transform target)
    {
        if (isDefeated || isFloating || target == null) return;
        isFloating = true;
        floatTarget = target;
        moveInput = 0f;
        floatVelocity = Vector2.zero;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void Defeat()
    {
        isDefeated = true;
        isFloating = false;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        UIManager.instance?.ShowDerrota();
    }

    public void Win()
    {
        isDefeated = true;
        isFloating = false;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        UIManager.instance?.ShowVictoria();
    }

    private void HandleFlip()
    {
        if (moveInput > 0 && !facingRight)
        {
            facingRight = true;
            sr.flipX = false;
        }
        else if (moveInput < 0 && facingRight)
        {
            facingRight = false;
            sr.flipX = true;
        }
    }
}
