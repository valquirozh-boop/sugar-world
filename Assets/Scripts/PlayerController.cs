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
    [SerializeField] private float floatDuration = 0.75f;
    [SerializeField] private float floatArcHeight = 5f;

    [Header("Audio")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip defeatClip;
    [SerializeField] [Range(0f, 1f)] private float jumpVolume = 0.7f;
    [SerializeField] [Range(0f, 1f)] private float defeatVolume = 0.8f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private AudioSource audioSource;
    private bool isGrounded;
    private bool isFloating;
    private float moveInput;
    private bool facingRight = true;
    private bool isDefeated = false;
    private Transform floatTarget;
    private Vector2 floatStartPos;
    private float floatElapsed;

    public bool IsGrounded => isGrounded;
    public bool IsMoving => Mathf.Abs(moveInput) > 0.01f;
    public bool IsFloating => isFloating;
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

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
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
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            PlayJumpSound();
        }

        HandleFlip();
    }

    private void FixedUpdate()
    {
        if (isDefeated) return;

        if (isFloating && floatTarget != null)
        {
            isGrounded = false;
            floatElapsed += Time.fixedDeltaTime;
            float t = Mathf.Clamp01(floatElapsed / floatDuration);
            t = t * t * (3f - 2f * t);

            Vector2 end = floatTarget.position;
            Vector2 control = (floatStartPos + end) * 0.5f + Vector2.up * floatArcHeight;
            Vector2 a = Vector2.Lerp(floatStartPos, control, t);
            Vector2 b = Vector2.Lerp(control, end, t);
            rb.MovePosition(Vector2.Lerp(a, b, t));
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
        floatStartPos = rb.position;
        floatElapsed = 0f;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
        PlayJumpSound();
    }

    public void Defeat()
    {
        if (isDefeated) return;

        isDefeated = true;
        isFloating = false;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        PlaySound(defeatClip, defeatVolume);
        UIManager.instance?.ShowDerrota();
    }

    public void Win()
    {
        if (isDefeated) return;

        isDefeated = true;
        isFloating = false;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        UIManager.instance?.ShowVictoria();
    }

    private void PlayJumpSound()
    {
        PlaySound(jumpClip, jumpVolume);
    }

    private void PlaySound(AudioClip clip, float volume)
    {
        if (clip != null && audioSource != null)
            audioSource.PlayOneShot(clip, volume);
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
