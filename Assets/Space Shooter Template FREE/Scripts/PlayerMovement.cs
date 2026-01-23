using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
<<<<<<< HEAD
    [Header("Movement")]
    public float speed = 5f;

    [Header("Shooting")]
    public GameObject bulletPrefab;      // kéo Bullet prefab vào đây
    public float autoFireInterval = 0.2f; // bắn auto khi đang di chuyển
    public float moveThreshold = 0.01f;   // ngưỡng để tính là đang di chuyển

    private Vector3 lastPosition;
    private float lastAutoFireTime;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        // ===== 1) DI CHUYỂN THEO CHUỘT =====
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        Vector3 target = Camera.main.ScreenToWorldPoint(mousePos);
        target.z = 0f;

=======
    public float speed = 5f;

    void Update()
    {
        // 1. Lấy vị trí chuột (world)
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; // khoảng cách từ camera
        Vector3 target =
            Camera.main.ScreenToWorldPoint(mousePos);

        target.z = 0f;

        // 2. Player đuổi theo chuột
>>>>>>> 6cfbf4a239524dbe365ec44c9510a4081ca346d7
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );
<<<<<<< HEAD

        // ===== 2) CLICK CHUỘT TRÁI -> BẮN 1 VIÊN =====
        if (Input.GetMouseButtonDown(0))
        {
            ShootOnce();
        }

        // ===== 3) NẾU ĐANG DI CHUYỂN -> AUTO BẮN =====
        float movedDistance = Vector3.Distance(transform.position, lastPosition);
        bool isMoving = movedDistance > moveThreshold;

        if (isMoving && Time.time - lastAutoFireTime >= autoFireInterval)
        {
            ShootOnce();
            lastAutoFireTime = Time.time;
        }

        lastPosition = transform.position;
    }

    void ShootOnce()
    {
        if (bulletPrefab == null) return;

        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
=======
>>>>>>> 6cfbf4a239524dbe365ec44c9510a4081ca346d7
    }
}
