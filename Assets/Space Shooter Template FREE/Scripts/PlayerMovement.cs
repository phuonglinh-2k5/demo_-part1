using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );
    }
}
