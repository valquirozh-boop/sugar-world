using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 12f;

    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private float moveInput;
    private bool facingRight = true;
    private bool isDefeated = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDefeated) return;
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
        UpdateAnimations();
    }

    private void FixedUpdate()
    {
        if (isDefeated) return;
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    public void Defeat()
    {
        isDefeated = true;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        UIManager.instance?.ShowDerrota();
    }

    public void Win()
    {
        isDefeated = true;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        UIManager.instance?.ShowVictoria();
    }

    private void HandleFlip()
    {
        if (moveInput > 0 && !facingRight) Flip();
        else if (moveInput < 0 && facingRight) Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    private void UpdateAnimations()
    {
        if (anim == null) return;
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
        anim.SetBool("IsGrounded", isGrounded);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        foreach (var contact in col.contacts)
            if (contact.normal.y > 0.5f) { isGrounded = true; return; }
    }

    private void OnCollisionExit2D(Collision2D col) => isGrounded = false;
}
