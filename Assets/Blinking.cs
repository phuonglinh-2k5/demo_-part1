using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Blinking : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [Tooltip("Time between blink on/off")]
    public float blinkInterval = 0.1f;

    private float nextBlinkTime;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError(
                "Blinking script must be attached to a GameObject with SpriteRenderer!"
            );
            enabled = false;
        }
    }

    void Update()
    {
        if (!spriteRenderer) return;

        if (Time.time >= nextBlinkTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            nextBlinkTime = Time.time + blinkInterval;
        }
    }
}
