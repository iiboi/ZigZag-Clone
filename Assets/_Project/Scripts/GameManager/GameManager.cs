using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] BallMovement ballMovement;
    int score = 0;
    int SpeedLevel = 1;

    public static GameManager instance;

    private void Awake() 
    {
        instance = this;
    }

    public void IncreaseScore()
    {
        score++;
        // Debug.Log($"Score: {score}");
        
        if (score % 50 == 0)
        {
            ballMovement.IncreaseSpeed();

            Debug.Log($"Speed Level: {SpeedLevel}");
            SpeedLevel++;
        }
    }
    
    
}
