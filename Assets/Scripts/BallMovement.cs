using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10;
    public Collider2D batRight;
    public Collider2D batLeft;
    public Collider2D goalLeft;
    public Collider2D goalRight;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    public void InitialBallImpulse()
    {
        rb.velocity = transform.right * speed;   // Der Ball startet nach Rechts mit der Velocity geschwindigkeit * speed;
    }

    public void ResetBall()
    {
        rb.velocity = Vector2.zero; // keine Geschwindigkeit auf X und Y
        transform.position = Vector2.zero; // Ball wird wieder 0,0,0 gesetzt
        GameManager.gameRunning = false;
    }


    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == batLeft || collision.collider == batRight) 
        {
            // Ball Kollision mit Schläger
            float y = transform.position.y - collision.transform.position.y; // Reichweite 0.5 bis -0.5 // Y-Position des Balles - der Position wo die Kollision
                                                                             // stattgefunden hat (position des Schlägers)
            Debug.Log(y);

            float x = 0;

            if (collision.collider == batLeft) // Falls Ball mit batLeft kollidiert wird er nach rechts geschleudert ansonsten nach links
                x = 1;
            else
                x = -1;

            Vector2 dir = new Vector2(x, y).normalized; //Führt die Kraft auf den Ball aus // Normalized = Maximale Einheit ist 1 und Winkel bleibt gleich
            rb.velocity = dir * speed;

            collision.transform.GetComponent<AudioSource>().Play();
        }

        // Ball Kollision mit Wand

        if (collision.collider == goalLeft || collision.collider == goalRight)
        {
            if (collision.collider == goalRight)
                FindObjectOfType<GameManager>().IncreaseScore(true);
            else
                FindObjectOfType<GameManager>().IncreaseScore(false);

            ResetBall();
        }
           


    }
}
