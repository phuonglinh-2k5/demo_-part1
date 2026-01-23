using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flySpeed = 8f;

    void Update()
    {
        transform.position += Vector3.up * flySpeed * Time.deltaTime;
    }
}
