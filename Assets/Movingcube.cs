using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private bool facingRight = true; // Hướng nhân vật (mặc định quay phải)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Nhận phím di chuyển
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        // Gọi hàm lật hướng
        FlipIfNeeded();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    void FlipIfNeeded()
    {
        // Nếu đang đi sang phải mà nhân vật đang quay trái → lật lại
        if (moveInput.x > 0 && !facingRight)
        {
            Flip();
        }
        // Nếu đang đi sang trái mà nhân vật đang quay phải → lật lại
        else if (moveInput.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        // Lật hình player bằng cách nhân trục X với -1
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
