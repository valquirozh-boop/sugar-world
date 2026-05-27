using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSpriteAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] idleFrames;
    [SerializeField] private Sprite[] walkFrames;
    [SerializeField] private Sprite[] jumpFrames;
    [SerializeField] private Sprite floatSprite;
    [SerializeField] private float frameRate = 12f;

    private SpriteRenderer sr;
    private PlayerController controller;
    private Sprite[] currentFrames;
    private int frameIndex;
    private float frameTimer;
    private Vector3 baseScale;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        baseScale = transform.localScale;
        SetFrames(idleFrames);
    }

    private void Update()
    {
        if (controller == null) return;

        if (controller.IsFloating)
        {
            if (floatSprite != null && sr.sprite != floatSprite)
            {
                sr.sprite = floatSprite;
                ApplyFloatScale();
            }
            return;
        }

        Sprite[] next = controller.InAir ? jumpFrames
            : controller.IsMoving ? walkFrames
            : idleFrames;

        if (next != currentFrames)
            SetFrames(next);

        if (currentFrames == null || currentFrames.Length == 0) return;

        frameTimer += Time.deltaTime;
        if (frameTimer < 1f / frameRate) return;

        frameTimer = 0f;
        frameIndex = (frameIndex + 1) % currentFrames.Length;
        sr.sprite = currentFrames[frameIndex];
    }

    private void SetFrames(Sprite[] frames)
    {
        currentFrames = frames;
        frameIndex = 0;
        frameTimer = 0f;
        if (frames != null && frames.Length > 0)
            sr.sprite = frames[0];
    }

    private void ApplyFloatScale()
    {
        Sprite reference = idleFrames != null && idleFrames.Length > 0 ? idleFrames[0] : sr.sprite;
        if (reference == null || floatSprite == null) return;

        float refSize = reference.bounds.size.y;
        float floatSize = floatSprite.bounds.size.y;
        if (floatSize <= 0f) return;

        transform.localScale = baseScale * (refSize / floatSize);
    }
}
