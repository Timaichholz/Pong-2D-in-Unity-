using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameRunning;

    public BallMovement ball;

    public int score1;
    public int score2;

    public Text scoreText1;
    public Text scoreText2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))        //StartRound wird erst ausgeführt sobald man Leertaste drückt
            StartRound();
    }

    private void StartRound()
    {
        if (gameRunning)
            return;

        gameRunning = true;
        ball.InitialBallImpulse();  // Bewegung des Balls wird erst gestartet wenn gameRunning auf true gesetzt wird
        Debug.Log("Round started");
    }

    public void IncreaseScore(bool player)
    {
        if (player)
            score1++;
        else
            score2++;
        UpdateScoreText();
        CheckEndMatch();
    }

    private void CheckEndMatch()
    {
        if(score1 == 3 || score2 == 3)
        {
            if (score1 == 3)
                Debug.Log("Player win!");
            else
                Debug.Log("AI win!");
            score1 = 0;
            score2 = 0;

            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        scoreText1.text = score1.ToString();
        scoreText2.text = score2.ToString();
    }

  
    
}
