using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSpriteAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] idleFrames;
    [SerializeField] private Sprite[] walkFrames;
    [SerializeField] private Sprite[] jumpFrames;
    [SerializeField] private float frameRate = 12f;

    private SpriteRenderer sr;
    private PlayerController controller;
    private Sprite[] currentFrames;
    private int frameIndex;
    private float frameTimer;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        SetFrames(idleFrames);
    }

    private void Update()
    {
        if (controller == null) return;

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
}
