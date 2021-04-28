using UnityEngine;

public class BatMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 10;

    private void Awake() //Wird aufgerufen sobald das Objekt "erwacht"
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical" ) * speed; // Holt uns den Y-Wert und multipliziert diesen mit der Variable "Speed" die im Editor geändert werden kann

        rb.velocity = new Vector2(0, v);   // X,Y - Wert
    }
}
