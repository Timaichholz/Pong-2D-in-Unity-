using UnityEngine;

public class AI : MonoBehaviour
{
    public float difficulty = 25;
    public BallMovement ball;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {                // Lerp = bewege dich dort hin (Da wo du bist, da wo du hin willst, wie schnell du dich dahin bewegen sollst)
                                 // Eigene Position                // X-Position irrelevant Y-Pos. des Balles           // Je mehr Zeit vergeht desto schneller
        Vector2 pos = Vector2.Lerp(transform.position, new Vector2(transform.position.x, ball.transform.position.y), difficulty * Time.deltaTime);
        rb.MovePosition(pos);
    }
}
