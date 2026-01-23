using UnityEngine;

<<<<<<< HEAD
[RequireComponent(typeof(SpriteRenderer))]
=======
>>>>>>> 6cfbf4a239524dbe365ec44c9510a4081ca346d7
public class Blinking : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

<<<<<<< HEAD
    [Tooltip("Time between blink on/off")]
    public float blinkInterval = 0.1f;

    private float nextBlinkTime;

=======
>>>>>>> 6cfbf4a239524dbe365ec44c9510a4081ca346d7
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError(
                "Blinking script must be attached to a GameObject with SpriteRenderer!"
            );
<<<<<<< HEAD
            enabled = false;
=======
            enabled = false; // TẮT SCRIPT để tránh spam lỗi
>>>>>>> 6cfbf4a239524dbe365ec44c9510a4081ca346d7
        }
    }

    void Update()
    {
<<<<<<< HEAD
        if (!spriteRenderer) return;

        if (Time.time >= nextBlinkTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            nextBlinkTime = Time.time + blinkInterval;
        }
=======
        spriteRenderer.enabled = !spriteRenderer.enabled;
>>>>>>> 6cfbf4a239524dbe365ec44c9510a4081ca346d7
    }
}
