using UnityEngine;

public class Blinking : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError(
                "Blinking script must be attached to a GameObject with SpriteRenderer!"
            );
            enabled = false; // TẮT SCRIPT để tránh spam lỗi
        }
    }

    void Update()
    {
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }
}
